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
    public partial class V_ManajemenStok : UserControl
    {
        public V_ManajemenStok()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void V_ManajemenStok_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            LoadDataStok();
        }

        public void LoadDataStok()
        {
            var controller = new C_Barang();
            DataTable dt = controller.GetAllBarang();
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row["id_barang"],
                    row["nama_barang"],
                    row["stok_barang"],
                    row["harga_barang"],
                    row["hpp"],
                    row["supplier_id_supplier"]
                );
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle tombol hapus
            if (e.ColumnIndex == dataGridView1.Columns["hapus"].Index && e.RowIndex >= 0)
            {
                // Dapatkan ID barang dari baris yang dipilih
                int idBarang = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_barang"].Value);

                // Konfirmasi penghapusan
                var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus barang ini?",
                                                  "Konfirmasi Hapus",
                                                  MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Panggil controller untuk menghapus
                    var controller = new C_Barang();
                    bool success = controller.HapusBarang(idBarang);

                    if (success)
                    {
                        MessageBox.Show("Barang berhasil dihapus");
                        LoadDataStok(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus barang");
                    }
                }
            }
        }

        private void StyleDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;

            // Header Style
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(89, 96, 124);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 36;

            // Cell Style
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(228, 228, 228);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Padding = new Padding(8);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Style khusus untuk tombol
            dataGridView1.Columns["hapus"].DefaultCellStyle.BackColor = Color.FromArgb(255, 100, 100);
            dataGridView1.Columns["hapus"].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns["hapus"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Border and lines
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            // Row and column sizing
            dataGridView1.RowTemplate.Height = 34;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["hapus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Biarkan lebar tetap
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V_TambahBarang v_TambahBarang = new V_TambahBarang();
            v_TambahBarang.BringToFront();
            v_TambahBarang.Show();
            this.Hide();
        }
    }
}