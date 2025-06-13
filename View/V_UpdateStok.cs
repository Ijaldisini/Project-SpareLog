using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_SpareLog.Core.Model;
using Project_SpareLog.Context;
using System.Reflection.Emit;

namespace Project_SpareLog.View
{
    public partial class V_UpdateStok : UserControl
    {
        private readonly C_Barang controller;
        private int _currentIdBarang;
        private int _currentStok;

        public V_UpdateStok()
        {
            InitializeComponent();
            controller = new C_Barang();
        }

        public void SetBarangData(int idBarang, string namaBarang, int currentStok)
        {
            _currentIdBarang = idBarang;
            _currentStok = currentStok;
            textBox1.Text = idBarang.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            V_ManajemenStok v_ManajemenStok = new V_ManajemenStok();
            this.Controls.Add(v_ManajemenStok);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Masukkan jumlah stok yang akan ditambahkan", "Warning",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Masukkan HPP baru", "Warning",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int jumlahStokBaru = Convert.ToInt32(textBox2.Text);
                int hppBaru = Convert.ToInt32(textBox3.Text);
                int hargaBaru = hppBaru + (int)(hppBaru * 0.1m);

                if (jumlahStokBaru <= 0)
                {
                    MessageBox.Show("Jumlah stok harus lebih dari 0", "Warning",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmResult = MessageBox.Show(
                    $"Tambahkan {jumlahStokBaru} ke stok saat ini ({_currentStok})? \n" +
                    $"Update HPP menjadi {hppBaru}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    bool successStok = controller.UpdateStokBarang(_currentIdBarang, jumlahStokBaru, hppBaru);
                    bool successHPP = controller.UpdateHPP(_currentIdBarang, hppBaru);
                    bool successHarga = controller.UpdateHargaBarang(_currentIdBarang, hargaBaru);

                    if (successStok && successHPP && successHarga)
                    {
                        MessageBox.Show("Stok, HPP, dan Harga berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    else
                    {
                        string errorMsg = "";
                        if (!successStok) errorMsg += "Gagal update stok\n";
                        if (!successHPP) errorMsg += "Gagal update HPP\n";
                        if (!successHarga) errorMsg += "Gagal update harga";

                        MessageBox.Show($"Beberapa update gagal:\n{errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format input tidak valid. Pastikan angka yang dimasukkan benar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
