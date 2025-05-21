using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_SpareLog.Controller;
using Project_SpareLog.Model;

namespace Project_SpareLog.View
{
    public partial class V_TransaksiPelanggan : UserControl
    {
        public V_TransaksiPelanggan()
        {
            InitializeComponent();
            StyleDataGridView();
            LoadBarangToDictionary(); // muat data barang ke ComboBox
            HitungTotalHarga();

            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            dataGridView1.RowsAdded += (s, e) => HitungTotalHarga();     // ⬅ Tambahkan ini
            dataGridView1.RowsRemoved += (s, e) => HitungTotalHarga();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string plat = textBox2.Text.Trim();
            DateTime tanggal = dateTimePicker1.Value;

            int totalTransaksi = 0;
            int jumlahBarang = 0;

            var controller = new C_Transaksi();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // Get the id_barang value
                string id_barang = row.Cells["id_barang"].Value?.ToString();

                // Add the validation and parsing block here:
                if (!int.TryParse(id_barang, out int barangId))
                {
                    MessageBox.Show($"ID Barang tidak valid: {id_barang}");
                    return;
                }

                if (!int.TryParse(row.Cells["jumlah_barang"].Value?.ToString(), out int qty))
                {
                    MessageBox.Show("Jumlah barang harus angka");
                    return;
                }

                if (!int.TryParse(row.Cells["harga"].Value?.ToString(), out int harga))
                {
                    MessageBox.Show("Harga barang tidak valid");
                    return;
                }

                jumlahBarang += qty;
                totalTransaksi += qty * harga;

                // Call KurangiStokBarang with the parsed integer
                if (!controller.KurangiStokBarang(barangId, qty))
                {
                    MessageBox.Show($"Gagal mengurangi stok barang ID: {barangId}");
                    return;
                }
            }

            var transaksi = new M_Transaksi
            {
                nama_transaksi = nama,
                tanggal_transaksi = tanggal,
                jumlah_barang = jumlahBarang,
                total_transaksi = totalTransaksi
            };

            if (controller.SimpanTransaksi(transaksi))
            {
                MessageBox.Show("Transaksi berhasil disimpan!");
                textBox1.Clear();
                textBox2.Clear();
                dateTimePicker1.Value = DateTime.Now;
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan transaksi.");
            }
        }

        private Dictionary<string, (int id, int harga)> barangDict = new();

        private void LoadBarangToDictionary()
        {
            var controller = new C_Transaksi();
            var dt = controller.GetDataBarang();

            barangDict.Clear();

            foreach (DataRow row in dt.Rows)
            {
                if (int.TryParse(row["id_barang"].ToString(), out int id_barang))
                {
                    string nama_barang = row["nama_barang"].ToString();
                    int harga_barang = Convert.ToInt32(row["harga_barang"]);
                    barangDict[nama_barang] = (id_barang, harga_barang);
                }
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;

            // Jika nama barang diedit
            if (e.ColumnIndex == 1)
            {
                string nama_barang = row.Cells[1].Value?.ToString();
                if (barangDict.TryGetValue(nama_barang, out var barangInfo))
                {
                    row.Cells[0].Value = barangInfo.id;
                    row.Cells[3].Value = barangInfo.harga;
                }
            }

            // Jika jumlah barang diedit, validasi atau hitung total harga per baris (opsional)
            if (e.ColumnIndex == 2) // asumsi kolom jumlah = index ke-2
            {
                if (int.TryParse(row.Cells[2].Value?.ToString(), out int jumlah) &&
                    int.TryParse(row.Cells[3].Value?.ToString(), out int harga))
                {
                    int totalHarga = jumlah * harga;
                    // Tambahkan kolom baru "Total Harga" jika ingin menampilkan per baris
                    // atau update label total keseluruhan langsung
                }
            }

            HitungTotalHarga();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Validasi kolom jumlah dan harga harus angka
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // index kolom jumlah dan harga
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out _))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Harus berupa angka";
                    e.Cancel = true;
                }
            }
        }
        private void HitungTotalHarga()
        {
            var controller = new C_Transaksi();
            int total = controller.HitungTotalHarga(dataGridView1);
            textBox3.Text = total.ToString("N0");
        }

        private void StyleDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(89, 96, 124);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 36;

            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(228, 228, 228);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Padding = new Padding(8);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowTemplate.Height = 34;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToResizeRows = false;
        }

    }
}
