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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                MessageBox.Show("Password tidak boleh kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                C_Login login = new C_Login();
                bool success = login.Login(password);

                if (success)
                {
                    MessageBox.Show("Login success!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    V_Dashboard dashboard = new V_Dashboard();
                    dashboard.Show();
                    this.Hide();
                    dashboard.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                textBox1.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
            }

            button3.BringToFront();
            button3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '\0')
            {
                textBox1.PasswordChar = '*';
            }
            else
            {
                textBox1.PasswordChar = '\0';
            }

            button2.BringToFront();
            button2.Show();
        }
    }
}
