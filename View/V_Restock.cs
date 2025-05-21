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

namespace Project_SpareLog.View
{
    public partial class V_Restock : UserControl
    {
        private C_Barang controller;
        public V_Restock()
        {
            InitializeComponent();
            controller = new C_Barang();
            this.Load += V_Restock_Load; // Pastikan event handler terdaftar

        }

        private void V_Restock_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            LoadBarangPerluRestock();
        }

        private void LoadBarangPerluRestock()
        {
            try
            {
                DataTable dt = controller.GetBarangPerluRestock();
                dataGridView1.Rows.Clear();

                // Debug: Cek jumlah baris yang diterima
                Console.WriteLine($"Jumlah baris diterima: {dt.Rows.Count}");

                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["id_barang"],
                        row["nama_barang"],
                        row["stok_barang"],
                        row["harga_barang"],
                        row["hpp"],
                        row["nama_supplier"]
                    );
                }

                // Tambahkan label jika tidak ada barang yang perlu direstock
                if (dataGridView1.Rows.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Tidak ada barang yang perlu direstock (stok semua barang ≥ 10)";
                    lblEmpty.Dock = DockStyle.Fill;
                    lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                    lblEmpty.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    this.Controls.Add(lblEmpty);
                    dataGridView1.Visible = false;
                }
                else
                {
                    dataGridView1.Visible = true;
                    // Hapus semua label yang mungkin ada sebelumnya
                    foreach (Control control in this.Controls)
                    {
                        if (control is Label)
                        {
                            this.Controls.Remove(control);
                            control.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Border and lines
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            // Row and column sizing
            dataGridView1.RowTemplate.Height = 34;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
        }
    }
}