﻿using System;
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
            v_TambahBarang1.Show();
            v_DashboardAwal1.Hide();
            button2.Show();
            button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            v_DashboardAwal1.BringToFront();
            v_DashboardAwal1.Show();
            v_ManajemenStok1.Hide();
            v_TambahBarang1.Hide();
            v_Restock1.Hide();
            v_TransaksiPelanggan1.Hide();
            button1.Show();
            button2.Hide();
        }

        private void v_TambahBarang1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            v_TransaksiPelanggan1.LoadBarangToDictionary();
            v_TransaksiPelanggan1.BringToFront();
            v_TransaksiPelanggan1.Show();
            v_DashboardAwal1.Hide();
            v_ManajemenStok1.Hide();
        }
    }
}
