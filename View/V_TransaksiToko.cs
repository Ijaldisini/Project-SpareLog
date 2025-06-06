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
using Project_SpareLog.Core.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                // Tambahkan ini:
                var hargaCell = dataGridView1.Rows[e.RowIndex].Cells["harga"];
                if (hargaCell.Value != null && int.TryParse(hargaCell.Value.ToString(), out int harga))
                {
                    int hargaDiskon = harga - (int)(harga * 0.05);
                    dataGridView1.Rows[e.RowIndex].Cells["harga_diskon"].Value = hargaDiskon;
                }

                HitungTotalToko();
            }
        }

        private void HitungTotalToko()
        {
            int total = controller.HitungTotalToko(dataGridView1);
            textBox3.Text = total.ToString("N0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V_TransaksiPelanggan v_TransaksiPelanggan = new V_TransaksiPelanggan();
            this.Controls.Add(v_TransaksiPelanggan);
            v_TransaksiPelanggan.BringToFront();
            v_TransaksiPelanggan.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string namaPelanggan = textBox3.Text.Trim();
            string noPolisi = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(namaPelanggan))
            {
                MessageBox.Show("Nama pelanggan harus diisi.");
                return;
            }

            int pelangganId = controller.GetIdPelanggan(namaPelanggan);
            textBox1.Text = pelangganId.ToString(); // tampilkan di TextBox1

            List<M_Transaksi> transaksiList = new List<M_Transaksi>();
            int total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["id_barang"].Value == null ||
                    row.Cells["jumlah"].Value == null ||
                    row.Cells["harga"].Value == null)
                    continue;

                var item = new M_Transaksi
                {
                    pelanggan_id_pelanggan = pelangganId,
                    user_id_user = 1,
                    barang_id_barang = Convert.ToInt32(row.Cells["id_barang"].Value),
                    jumlah_detail_transaksi = Convert.ToInt32(row.Cells["jumlah"].Value),
                    harga_detail_transaksi = Convert.ToInt32(row.Cells["harga"].Value)
                };

                transaksiList.Add(item);

                var controllerBarang = new C_Barang();
                bool kurangiStok = controllerBarang.KurangiStokBarang(Convert.ToInt32(row.Cells["id_barang"].Value), Convert.ToInt32(row.Cells["jumlah"].Value));
                if (!kurangiStok)
                {
                    MessageBox.Show("Gagal mengurangi stok untuk barang " + row.Cells["nama_barang"].Value.ToString());
                    return; // Berhenti jika stok gagal dikurangi
                }
            }

            textBox3.Text = total.ToString();

            bool success = controller.SimpanTransaksi(transaksiList);
            if (success)
            {
                MessageBox.Show("Transaksi berhasil disimpan.");
                dataGridView1.Rows.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan transaksi.");
            }
        }
    }
}
