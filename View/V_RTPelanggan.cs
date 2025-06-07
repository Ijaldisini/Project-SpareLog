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

namespace Project_SpareLog.View
{
    public partial class V_RTPelanggan : UserControl
    {
        private ARiwayatTransaksiService riwayatTransaksiService;

        public V_RTPelanggan()
        {
            riwayatTransaksiService = new C_RiwayatTransaksi();
            InitializeComponent();

            textBox1.KeyDown += TextBox1_KeyDown; // Updated event subscription
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e) // Changed event handler to KeyDown
        {
            if (e.KeyCode == Keys.Enter)
            {
                string nama = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(nama))
                {
                    var data = riwayatTransaksiService.GetRiwayatByNamaPelanggan(nama);
                    LoadDataGrid(data);
                }
            }
        }

        private void LoadDataGrid(List<M_RiwayatTransaksi> riwayat)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in riwayat)
            {
                dataGridView1.Rows.Add(
                    item.id_transaksi,
                    item.tanggal_transaksi.ToShortDateString(),
                    item.pelanggan_id_pelanggan,
                    item.barang_id_barang,
                    item.jumlah_detail_transaksi,
                    item.harga_detail_transaksi
                );
            }

            int total = 0;
            foreach (var item in riwayat)
            {
                total += item.jumlah_detail_transaksi * item.harga_detail_transaksi; ;
            }
            textBox2.Text = total.ToString("N0");
        }

        private void StyleDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            // Header style
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(89, 96, 124);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 40;

            // Cell style
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
            dataGridView1.AllowUserToAddRows = true; // <-- Penting untuk tetap bisa input
            dataGridView1.AllowUserToResizeRows = false;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Height = 40; // atau tinggi sesuai kebutuhan
            }
        }

        private void V_RTPelanggan_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            LoadDataGrid(riwayatTransaksiService.GetAllRiwayatPelanggan());
        }
    }
}
