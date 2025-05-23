using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Project_SpareLog.Controller;
using Project_SpareLog.Model;

namespace Project_SpareLog.View
{
    public partial class V_TransaksiPelanggan : UserControl
    {
        private readonly Dictionary<string, (int id, int harga)> barangDict = new Dictionary<string, (int id, int harga)>();
        private readonly C_Transaksi controller;

        public V_TransaksiPelanggan()
        {
            InitializeComponent();
            controller = new C_Transaksi();

            InitializeUI();
            InitializeData();
            ConfigureRowHeights();
        }

        private void InitializeUI()
        {
            StyleDataGridView();
            ConfigureInitialRowHeight();
        }

        private void InitializeData()
        {
            LoadBarangToDictionary();
            HitungTotalHarga();

            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            dataGridView1.RowsAdded += (s, e) => HitungTotalHarga();
            dataGridView1.RowsRemoved += (s, e) => HitungTotalHarga();
        }

        private void ConfigureInitialRowHeight()
        {
            dataGridView1.RowTemplate.Height = 40; // Increased row height
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[0].Height = 50; // Extra height for first row
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var (success, totalTransaksi, jumlahBarang) = ProcessTransactionItems();
            if (!success) return;

            SaveTransaction(totalTransaksi, jumlahBarang);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Nama pelanggan harus diisi");
                return false;
            }
            return true;
        }

        private (bool success, int totalTransaksi, int jumlahBarang) ProcessTransactionItems()
        {
            int totalTransaksi = 0;
            int jumlahBarang = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (!ValidateRow(row, out int barangId, out int qty, out int harga))
                    return (false, 0, 0);

                jumlahBarang += qty;
                totalTransaksi += qty * harga;

                if (!controller.KurangiStokBarang(barangId, qty))
                {
                    MessageBox.Show($"Gagal mengurangi stok barang ID: {barangId}");
                    return (false, 0, 0);
                }
            }

            return (true, totalTransaksi, jumlahBarang);
        }

        private bool ValidateRow(DataGridViewRow row, out int barangId, out int qty, out int harga)
        {
            barangId = 0;
            qty = 0;
            harga = 0;

            if (!int.TryParse(row.Cells["id_barang"].Value?.ToString(), out barangId))
            {
                MessageBox.Show("ID Barang tidak valid");
                return false;
            }

            if (!int.TryParse(row.Cells["jumlah_barang"].Value?.ToString(), out qty))
            {
                MessageBox.Show("Jumlah barang harus angka");
                return false;
            }

            if (!int.TryParse(row.Cells["harga"].Value?.ToString(), out harga))
            {
                MessageBox.Show("Harga barang tidak valid");
                return false;
            }

            return true;
        }

        private void SaveTransaction(int totalTransaksi, int jumlahBarang)
        {
            var transaksi = new M_Transaksi
            {
                nama_transaksi = textBox1.Text.Trim(),
                tanggal_transaksi = dateTimePicker1.Value,
                jumlah_barang = jumlahBarang,
                total_transaksi = totalTransaksi
            };

            if (controller.SimpanTransaksi(transaksi))
            {
                MessageBox.Show("Transaksi berhasil disimpan!");
                ResetForm();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan transaksi.");
            }
        }

        private void ResetForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.Rows.Clear();
            ConfigureInitialRowHeight(); // Reset with initial row
        }

        public void LoadBarangToDictionary()
        {
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
            row.ErrorText = string.Empty;

            if (e.ColumnIndex == 1) // Nama barang column
            {
                UpdateBarangInfoFromDictionary(row);
            }

            HitungTotalHarga();
        }

        private void UpdateBarangInfoFromDictionary(DataGridViewRow row)
        {
            string nama_barang = row.Cells[1].Value?.ToString();
            if (barangDict.TryGetValue(nama_barang, out var barangInfo))
            {
                row.Cells[0].Value = barangInfo.id;
                row.Cells[3].Value = barangInfo.harga;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // Quantity or price columns
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
            int total = controller.HitungTotalHarga(dataGridView1);
            textBox3.Text = total.ToString("N0");
        }

        private void ConfigureRowHeights()
        {
            // Atur tinggi default untuk semua baris
            dataGridView1.RowTemplate.Height = 36;

            // Tambahkan baris pertama jika belum ada
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Add();
            }

            // Atur tinggi khusus untuk baris pertama
            dataGridView1.Rows[0].Height = 34; // Tinggi lebih besar untuk baris pertama

            // Atur padding untuk membuat teks lebih mudah dibaca
            //dataGridView1.Rows[0].DefaultCellStyle.Padding = new Padding(0, 10, 0, 10);
        }

        private void StyleDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            // Header Style
            dataGridView1.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(89, 96, 124),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
            };
            dataGridView1.ColumnHeadersHeight = 36;

            // Cell Style
            dataGridView1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(228, 228, 228),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Padding = new Padding(8),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
            };

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.RowTemplate.Height = 34;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToResizeRows = false;
        }

private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}