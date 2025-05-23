﻿namespace Project_SpareLog.View
{
    partial class V_Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_Dashboard));
            label1 = new Label();
            panel1 = new Panel();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            v_ManajemenStok1 = new V_ManajemenStok();
            v_DashboardAwal1 = new V_DashboardAwal();
            v_TambahBarang1 = new V_TambahBarang();
            v_Restock1 = new V_Restock();
            v_TransaksiPelanggan1 = new V_TransaksiPelanggan();
            v_TransaksiToko1 = new V_TransaksiToko();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(1890, 9);
            label1.Name = "label1";
            label1.Size = new Size(18, 20);
            label1.TabIndex = 0;
            label1.Text = "X";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 1080);
            panel1.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(33, 452);
            button3.Name = "button3";
            button3.Size = new Size(279, 82);
            button3.TabIndex = 6;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(33, 329);
            button1.Name = "button1";
            button1.Size = new Size(279, 82);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(33, 329);
            button2.Name = "button2";
            button2.Size = new Size(279, 82);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // v_ManajemenStok1
            // 
            v_ManajemenStok1.BackColor = Color.Transparent;
            v_ManajemenStok1.BackgroundImage = (Image)resources.GetObject("v_ManajemenStok1.BackgroundImage");
            v_ManajemenStok1.BackgroundImageLayout = ImageLayout.Zoom;
            v_ManajemenStok1.Location = new Point(392, 62);
            v_ManajemenStok1.Name = "v_ManajemenStok1";
            v_ManajemenStok1.Size = new Size(1426, 941);
            v_ManajemenStok1.TabIndex = 2;
            // 
            // v_DashboardAwal1
            // 
            v_DashboardAwal1.BackColor = Color.Transparent;
            v_DashboardAwal1.BackgroundImage = (Image)resources.GetObject("v_DashboardAwal1.BackgroundImage");
            v_DashboardAwal1.BackgroundImageLayout = ImageLayout.Zoom;
            v_DashboardAwal1.Location = new Point(392, 62);
            v_DashboardAwal1.Name = "v_DashboardAwal1";
            v_DashboardAwal1.Size = new Size(1426, 941);
            v_DashboardAwal1.TabIndex = 3;
            // 
            // v_TambahBarang1
            // 
            v_TambahBarang1.BackColor = Color.Transparent;
            v_TambahBarang1.BackgroundImage = (Image)resources.GetObject("v_TambahBarang1.BackgroundImage");
            v_TambahBarang1.BackgroundImageLayout = ImageLayout.Zoom;
            v_TambahBarang1.Location = new Point(392, 62);
            v_TambahBarang1.Name = "v_TambahBarang1";
            v_TambahBarang1.Size = new Size(1426, 941);
            v_TambahBarang1.TabIndex = 4;
            v_TambahBarang1.Load += v_TambahBarang1_Load;
            // 
            // v_Restock1
            // 
            v_Restock1.BackColor = Color.Transparent;
            v_Restock1.BackgroundImage = (Image)resources.GetObject("v_Restock1.BackgroundImage");
            v_Restock1.BackgroundImageLayout = ImageLayout.Zoom;
            v_Restock1.Location = new Point(392, 62);
            v_Restock1.Name = "v_Restock1";
            v_Restock1.Size = new Size(1426, 941);
            v_Restock1.TabIndex = 5;
            // 
            // v_TransaksiPelanggan1
            // 
            v_TransaksiPelanggan1.BackColor = Color.Transparent;
            v_TransaksiPelanggan1.BackgroundImage = (Image)resources.GetObject("v_TransaksiPelanggan1.BackgroundImage");
            v_TransaksiPelanggan1.BackgroundImageLayout = ImageLayout.Zoom;
            v_TransaksiPelanggan1.Location = new Point(392, 62);
            v_TransaksiPelanggan1.Name = "v_TransaksiPelanggan1";
            v_TransaksiPelanggan1.Size = new Size(1426, 941);
            v_TransaksiPelanggan1.TabIndex = 6;
            // 
            // v_TransaksiToko1
            // 
            v_TransaksiToko1.BackColor = Color.Transparent;
            v_TransaksiToko1.BackgroundImage = (Image)resources.GetObject("v_TransaksiToko1.BackgroundImage");
            v_TransaksiToko1.Location = new Point(392, 62);
            v_TransaksiToko1.Name = "v_TransaksiToko1";
            v_TransaksiToko1.Size = new Size(1426, 941);
            v_TransaksiToko1.TabIndex = 7;
            // 
            // V_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1920, 1080);
            Controls.Add(v_DashboardAwal1);
            Controls.Add(v_ManajemenStok1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(v_TambahBarang1);
            Controls.Add(v_Restock1);
            Controls.Add(v_TransaksiPelanggan1);
            Controls.Add(v_TransaksiToko1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "V_Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "V_Dashboard";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button button1;
        private V_ManajemenStok v_ManajemenStok1;
        private V_DashboardAwal v_DashboardAwal1;
        private Button button2;
        private V_TambahBarang v_TambahBarang1;
        private V_Restock v_Restock1;
        private Button button3;
        private V_TransaksiPelanggan v_TransaksiPelanggan1;
        private V_TransaksiToko v_TransaksiToko1;
    }
}