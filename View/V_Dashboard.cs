using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SpareLog.View
{
    public partial class V_Dashboard : Form
    {
        public V_Dashboard()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v_ManajemenStok1.LoadDataStok();
            v_Restock1.LoadBarangPerluRestock();
            v_ManajemenStok1.BringToFront();
            v_ManajemenStok1.Show();
            v_DashboardAwal1.Hide();
            btnmanajemenklik.Show();
            button1.Hide();
            btntransaksiklik.Hide();
            button4.Show();
            button2.Show();
            button5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            v_rtPelanggan1.BringToFront();
            v_rtPelanggan1.Show();
            v_DashboardAwal1.Hide();
            btntransaksiklik.Show();
            button1.Show();
            button4.Show();
            button5.Show();
        }

        private void v_TambahBarang1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            v_DashboardAwal1.BringToFront();
            v_DashboardAwal1.Show();
            v_ManajemenStok1.Hide();
            btnmanajemenklik.Hide();
            button1.Show();
            btntransaksiklik.Hide();
            button4.Show();
            btnriwayatklik.Hide();
            button2.Show();
            button5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Hide();
            btnmanajemenklik.Hide();
            button1.Show();
            button2.Show();
            button5.Show();
            btntransaksiklik.Show();
            v_TransaksiPelanggan1.BringToFront();
            v_TransaksiPelanggan1.Show();
            v_DashboardAwal1.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Hide();
            btnlaporanklik.Show();
            button1.Show();
            button2.Show();
            button4.Show();
            v_LaporanPenjualan1.BringToFront();
            v_LaporanPenjualan1.Show();
            v_DashboardAwal1.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Apakah anda ingin Logout?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}