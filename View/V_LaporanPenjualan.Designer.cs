﻿namespace Project_SpareLog.View
{
    partial class V_LaporanPenjualan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_LaporanPenjualan));
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            id_barang = new DataGridViewTextBoxColumn();
            nama_barang = new DataGridViewTextBoxColumn();
            jumlah_terjual = new DataGridViewTextBoxColumn();
            harga_jual = new DataGridViewTextBoxColumn();
            harga_total = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.Transparent;
            dateTimePicker1.CalendarTitleBackColor = Color.Transparent;
            dateTimePicker1.CalendarTrailingForeColor = Color.Transparent;
            dateTimePicker1.ImeMode = ImeMode.NoControl;
            dateTimePicker1.Location = new Point(263, 227);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(302, 27);
            dateTimePicker1.TabIndex = 19;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_barang, nama_barang, jumlah_terjual, harga_jual, harga_total });
            dataGridView1.Location = new Point(83, 279);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1255, 570);
            dataGridView1.TabIndex = 20;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightGray;
            textBox1.Location = new Point(1213, 856);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 21;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(22, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(315, 59);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(1170, 29);
            button2.Name = "button2";
            button2.Size = new Size(218, 56);
            button2.TabIndex = 24;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(928, 29);
            button1.Name = "button1";
            button1.Size = new Size(218, 56);
            button1.TabIndex = 23;
            button1.UseVisualStyleBackColor = true;
            // 
            // id_barang
            // 
            id_barang.HeaderText = "ID Barang";
            id_barang.MinimumWidth = 6;
            id_barang.Name = "id_barang";
            id_barang.ReadOnly = true;
            id_barang.Width = 125;
            // 
            // nama_barang
            // 
            nama_barang.HeaderText = "Nama Barang";
            nama_barang.MinimumWidth = 6;
            nama_barang.Name = "nama_barang";
            nama_barang.ReadOnly = true;
            nama_barang.Width = 125;
            // 
            // jumlah_terjual
            // 
            jumlah_terjual.HeaderText = "Jumlah Terjual";
            jumlah_terjual.MinimumWidth = 6;
            jumlah_terjual.Name = "jumlah_terjual";
            jumlah_terjual.ReadOnly = true;
            jumlah_terjual.Width = 125;
            // 
            // harga_jual
            // 
            harga_jual.HeaderText = "Harga Jual";
            harga_jual.MinimumWidth = 6;
            harga_jual.Name = "harga_jual";
            harga_jual.ReadOnly = true;
            harga_jual.Width = 125;
            // 
            // harga_total
            // 
            harga_total.HeaderText = "Harga Total";
            harga_total.MinimumWidth = 6;
            harga_total.Name = "harga_total";
            harga_total.ReadOnly = true;
            harga_total.Width = 125;
            // 
            // V_LaporanPenjualan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
            DoubleBuffered = true;
            Name = "V_LaporanPenjualan";
            Size = new Size(1426, 941);
            Load += V_LaporanPenjualan_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id_transaksi;
        private DataGridViewTextBoxColumn tanggal_transaksi;
        private DataGridViewTextBoxColumn id_pelanggan;
        private DataGridViewTextBoxColumn jumlah;
        private DataGridViewTextBoxColumn harga;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button1;
        private DataGridViewTextBoxColumn id_barang;
        private DataGridViewTextBoxColumn nama_barang;
        private DataGridViewTextBoxColumn jumlah_terjual;
        private DataGridViewTextBoxColumn harga_jual;
        private DataGridViewTextBoxColumn harga_total;
    }
}
