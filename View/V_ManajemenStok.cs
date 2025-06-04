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
using System.IO;
using Project_SpareLog.Properties;

namespace Project_SpareLog.View
{
    public partial class V_ManajemenStok : UserControl
    {
        public V_ManajemenStok()
        {
            InitializeComponent();
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
                int idBarang = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_barang"].Value);

                var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menghapus barang ini?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    var controller = new C_Barang();
                    bool success = controller.HapusBarang(idBarang);

                    if (success)
                    {
                        MessageBox.Show("Barang berhasil dihapus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataStok();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus barang");
                    }
                }

                if (confirmResult == DialogResult.No)
                {
                    return;
                }
            }

            // Handle tombol update stok
            if (e.ColumnIndex == dataGridView1.Columns["tambah_stok"].Index && e.RowIndex >= 0)
            {
                try
                {
                    int idBarang = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_barang"].Value);
                    string namaBarang = dataGridView1.Rows[e.RowIndex].Cells["nama_barang"].Value.ToString();
                    int stokSaatIni = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["jumlah_stok"].Value);

                    // Langsung buka form update stok
                    V_UpdateStok v_UpdateStok = new V_UpdateStok();
                    V_TambahBarang v_TambahBarang = new V_TambahBarang();
                    v_UpdateStok.SetBarangData(idBarang, namaBarang, stokSaatIni);
                    this.Controls.Add(v_UpdateStok);
                    v_UpdateStok.BringToFront();
                    v_UpdateStok.Show();
                    v_TambahBarang.Hide();
                    LoadDataStok();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
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
            dataGridView1.ColumnHeadersHeight = 45;

            // Cell Style
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(228, 228, 228);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Padding = new Padding(8);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Grid & Border
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;

            // Row height
            dataGridView1.RowTemplate.Height = 45;

            // AutoSize columns (fill except for tombol)
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Matikan opsi tambahan pengguna
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;

            // Setup kolom tombol (gambar dan ukuran tetap)
            if (dataGridView1.Columns.Contains("hapus"))
            {
                dataGridView1.Columns["hapus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["hapus"].Width = 40;
            }

            if (dataGridView1.Columns.Contains("tambah_stok"))
            {
                dataGridView1.Columns["tambah_stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["tambah_stok"].Width = 40;
            }

            // Replace tombol teks dengan gambar (di CellPainting)
            dataGridView1.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridView1.Columns["hapus"].Index || e.ColumnIndex == dataGridView1.Columns["tambah_stok"].Index))
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

                    Image img = null;
                    if (e.ColumnIndex == dataGridView1.Columns["hapus"].Index)
                    {
                        img = Image.FromFile(@"D:\Kulyeah\PBO\Tugas\Tugas Besar\Project SpareLog\Resources\delete.png"); // pastikan ada file Resources dengan nama 'trash'
                    }
                    else if (e.ColumnIndex == dataGridView1.Columns["tambah_stok"].Index)
                    {
                        img = Image.FromFile(@"D:\Kulyeah\PBO\Tugas\Tugas Besar\Project SpareLog\Resources\Pen.png"); // pastikan ada file Resources dengan nama 'plus'
                    }

                    if (img != null)
                    {
                        int imgX = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                        int imgY = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;
                        e.Graphics.DrawImage(img, new Rectangle(imgX, imgY, img.Width, img.Height));
                    }

                    e.Handled = true;
                }
            };
        }


        private void button1_Click(object sender, EventArgs e)
        {
            V_TambahBarang v_TambahBarang = new V_TambahBarang();
            this.Controls.Add(v_TambahBarang);
            v_TambahBarang.BringToFront();
            v_TambahBarang.Show();
        }
    }
}