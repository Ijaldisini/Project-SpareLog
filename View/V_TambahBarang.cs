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
    public partial class V_TambahBarang : UserControl
    {
        private C_Barang controller;

        public V_TambahBarang()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                controller = new C_Barang();
            }

            Load += V_TambahBarang_Load;
            textBox2.Leave += TextBox2_Leave;
            textBox4.TextChanged += TextBox4_TextChanged;
            button1.Click += Button1_Click;
        }

        private void V_TambahBarang_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            controller = controller ?? new C_Barang();

            DataTable dt = controller.GetSuppliers();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nama_supplier";
            comboBox1.ValueMember = "id_supplier";
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (DesignMode) return;

            string namaBarang = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(namaBarang)) return;

            int? idBarang = controller.GetIdBarangByNama(namaBarang);
            textBox1.Text = idBarang?.ToString() ?? controller.GetNextIdBarang().ToString();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox4.Text, out decimal harga))
            {
                int hpp = (int)(harga - (harga * 0.1m)); // HPP = 90% dari harga, hasilnya dikonversi ke int
                textBox5.Text = hpp.ToString();
            }
            else
            {
                textBox5.Text = string.Empty; // kosongkan jika input tidak valid
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                M_Barang barang = new M_Barang
                {
                    id_barang = int.Parse(textBox1.Text),
                    nama_barang = textBox2.Text,
                    stok_barang = int.Parse(textBox3.Text),
                    harga_barang = int.Parse(textBox4.Text),
                    hpp = decimal.Parse(textBox5.Text),
                    supplier_id_supplier = Convert.ToInt32(comboBox1.SelectedValue)
                };

                controller = controller ?? new C_Barang();
                bool success = controller.SimpanBarang(barang);
                MessageBox.Show(success ? "Barang berhasil disimpan." : "Gagal menyimpan barang.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }

}
