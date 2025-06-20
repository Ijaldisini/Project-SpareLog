﻿using System;
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

            textBox1.Leave += TextBox1_Leave;
            Load += V_TambahBarang_Load;
            textBox2.Leave += TextBox2_Leave;
            textBox5.TextChanged += TextBox5_TextChanged;
            button1.Click += Button1_Click;
        }

        private void V_TambahBarang_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode) return;

                controller = controller ?? new C_Barang();

                DataTable dt = controller.GetSuppliers();
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "nama_supplier";
                comboBox1.ValueMember = "id_supplier";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode) return;

                if (int.TryParse(textBox1.Text.Trim(), out int idBarang))
                {
                    string namaBarang = controller.GetNamaBarangById(idBarang);
                    if (!string.IsNullOrEmpty(namaBarang))
                    {
                        textBox2.Text = namaBarang;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving barang: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode) return;

                string namaBarang = textBox2.Text.Trim();
                if (string.IsNullOrEmpty(namaBarang)) return;

                int? idBarang = controller.GetIdBarangByNama(namaBarang);
                textBox1.Text = idBarang?.ToString() ?? controller.GetNextIdBarang().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving barang ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int harga))
            {
                int hpp = (int)(harga + (harga * 0.1m));
                textBox4.Text = hpp.ToString();
            }
            else
            {
                textBox4.Text = string.Empty;
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
                    hpp = int.Parse(textBox5.Text),
                    supplier_id_supplier = Convert.ToInt32(comboBox1.SelectedValue)
                };

                controller = controller ?? new C_Barang();
                bool success = controller.SimpanBarang(barang);
                if (success)
                {
                    MessageBox.Show("Barang berhasil disimpan!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }

                else
                {
                    MessageBox.Show("Gagal menyimpan barang!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            V_TambahBarang_Load(sender, e);
            V_Restock v_Restock = new V_Restock();
            this.Controls.Add(v_Restock);
            v_Restock.BringToFront();
            v_Restock.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            V_ManajemenStok v_ManajemenStok = new V_ManajemenStok();
            V_Restock v_Restock = new V_Restock();
            this.Controls.Add(v_ManajemenStok);
            v_ManajemenStok.BringToFront();
            v_ManajemenStok.Show();
            v_Restock.Hide();
        }
    }
}
