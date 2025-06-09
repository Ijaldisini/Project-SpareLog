using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_SpareLog.Context;
using Project_SpareLog.Core.Abstract;
using Project_SpareLog.Core.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_SpareLog.View
{
    public partial class V_LaporanPenjualan : UserControl
    {
        private ALaporanService laporanService;

        public V_LaporanPenjualan()
        {
            laporanService = new C_Laporan();
            InitializeComponent();
        }

        private void V_LaporanPenjualan_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            LoadLaporan();
        }

        private void LoadLaporan()
        {
            // Bersihkan data lama
            dataGridView1.Rows.Clear();

            var laporan = laporanService.GetLaporanPenjualan();

            foreach (var item in laporan)
            {
                dataGridView1.Rows.Add(
                    item.id_barang,
                    item.nama_barang,
                    item.jumlah_terjual,
                    item.harga_jual,
                    item.harga_total
                );
            }

            // Hitung total seluruh penjualan hari itu
            int total = laporan.Sum(l => l.harga_total);
            textBox1.Text = total.ToString("N0");
        }

        private void LoadDataGrid(List<M_Laporan> laporan)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in laporan)
            {
                dataGridView1.Rows.Add(
                    item.id_barang,
                    item.nama_barang,
                    item.jumlah_terjual,
                    item.harga_jual,
                    item.harga_total
                );
            }

            int total = 0;
            foreach (var item in laporan)
            {
                total += item.harga_total;
            }
            textBox1.Text = total.ToString("N0");
        }

        private void StyleDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            // Header Style
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(89, 96, 124);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 40;

            // Cell Style
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(228, 228, 228);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Padding = new Padding(8);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Border and lines
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            // Row and column sizing
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            var data = laporanService.GetLaporanPenjualanByTanggal(selectedDate);
            LoadDataGrid(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            V_LaporanPembelian pembelian = new V_LaporanPembelian();
            this.Controls.Add(pembelian);
            pembelian.BringToFront();
            pembelian.Show();
        }
    }
}