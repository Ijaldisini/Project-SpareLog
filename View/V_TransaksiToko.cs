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

namespace Project_SpareLog.View
{
    public partial class V_TransaksiToko : UserControl
    {
        private C_Transaksi controller;

        public V_TransaksiToko()
        {
            controller = new C_Transaksi();
            InitializeComponent();
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            textBox2.Leave += TextBox2_Leave;
        }

        private void V_TransaksiToko_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (DesignMode) return;

            string namaPelanggan = textBox2.Text.Trim();
            if (!string.IsNullOrEmpty(namaPelanggan))
            {
                try
                {
                    int idPelanggan = controller.GetIdPelanggan(namaPelanggan);
                    textBox1.Text = idPelanggan.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mendapatkan ID pelanggan: " + ex.Message);
                }
            }
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "nama_barang")
            {
                var namaCell = dataGridView1.Rows[e.RowIndex].Cells["nama_barang"];
                if (namaCell.Value != null)
                {
                    string namaBarang = namaCell.Value.ToString();
                    var controller = new C_Barang();
                    string detail = controller.GetDetailBarang(namaBarang);

                    if (!string.IsNullOrEmpty(detail))
                    {
                        string[] parts = detail.Split('|');
                        if (parts.Length == 2 &&
                            int.TryParse(parts[0], out int idBarang) &&
                            int.TryParse(parts[1], out int hargaBarang))
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["id_barang"].Value = idBarang;
                            dataGridView1.Rows[e.RowIndex].Cells["harga"].Value = hargaBarang;
                        }
                    }
                }
            }

            if (e.RowIndex >= 0 && (dataGridView1.Columns[e.ColumnIndex].Name == "jumlah" ||
                                   dataGridView1.Columns[e.ColumnIndex].Name == "harga_diskon"))
            {
                HitungTotalKeseluruhan();
            }
        }

        private void HitungTotalKeseluruhan()
        {
            int total = controller.HitungTotalKeseluruhan(dataGridView1);
            textBox3.Text = total.ToString("N0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V_TransaksiPelanggan v_TransaksiPelanggan = new V_TransaksiPelanggan();
            this.Controls.Add(v_TransaksiPelanggan);
            v_TransaksiPelanggan.BringToFront();
            v_TransaksiPelanggan.Show();
        }
    }
}
