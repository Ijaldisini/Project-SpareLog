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
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Hide();
            btnmanajemenklik.Hide();
            button1.Show();
            btntransaksiklik.Show();
            v_TransaksiPelanggan1.BringToFront();
            v_TransaksiPelanggan1.Show();
            v_DashboardAwal1.Hide();
        }
    }
}