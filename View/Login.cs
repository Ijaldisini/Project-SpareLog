using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Project_SpareLog.App.Core;
using Project_SpareLog.Context;

namespace Project_SpareLog.View
{
    public partial class Login : Form
    {
        private readonly DatabaseWrapper db;
        public Login()
        {
            InitializeComponent();
            db = new DatabaseWrapper();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                C_Login login = new C_Login();
                bool success = login.Login(password);

                if (success)
                {
                    MessageBox.Show("Login success!!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    V_Dashboard dashboard = new V_Dashboard();
                    dashboard.Show();
                    this.Hide();
                    dashboard.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
