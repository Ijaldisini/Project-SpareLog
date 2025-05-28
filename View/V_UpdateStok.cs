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

        // Method untuk mengisi data barang yang akan diupdate
        public void SetBarangData(int idBarang, string namaBarang, int currentStok)
        {
            _currentIdBarang = idBarang;
            _currentStok = currentStok;

            textBox1.Text = idBarang.ToString();
        }

        //internal void ShowDialog()
        //{
        //    throw new NotImplementedException();
        //}

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
                // Validasi input
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Masukkan jumlah stok yang akan ditambahkan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int jumlahStokBaru = Convert.ToInt32(textBox2.Text);

                if (jumlahStokBaru <= 0)
                {
                    MessageBox.Show("Jumlah stok harus lebih dari 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Konfirmasi
                var confirmResult = MessageBox.Show($"Tambahkan {jumlahStokBaru} ke stok saat ini ({_currentStok})?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Gunakan _controller yang sudah diinisialisasi
                    bool success = controller.UpdateStokBarang(_currentIdBarang, jumlahStokBaru);

                    if (success)
                    {
                        MessageBox.Show($"Stok berhasil ditambahkan!\nStok baru: {_currentStok + jumlahStokBaru}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Gagal memperbarui stok", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Jumlah stok harus berupa angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
