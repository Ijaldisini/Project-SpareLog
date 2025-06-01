namespace Project_SpareLog.View
{
    partial class V_TransaksiPelanggan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_TransaksiPelanggan));
            dataGridView1 = new DataGridView();
            id_barang = new DataGridViewTextBoxColumn();
            nama_barang = new DataGridViewTextBoxColumn();
            jumlah = new DataGridViewTextBoxColumn();
            harga = new DataGridViewTextBoxColumn();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_barang, nama_barang, jumlah, harga });
            dataGridView1.Location = new Point(83, 324);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1255, 446);
            dataGridView1.TabIndex = 0;
            // 
            // id_barang
            // 
            id_barang.HeaderText = "ID Barang";
            id_barang.MinimumWidth = 6;
            id_barang.Name = "id_barang";
            id_barang.Width = 125;
            // 
            // nama_barang
            // 
            nama_barang.HeaderText = "Nama Barang";
            nama_barang.MinimumWidth = 6;
            nama_barang.Name = "nama_barang";
            nama_barang.Width = 125;
            // 
            // jumlah
            // 
            jumlah.HeaderText = "Jumlah";
            jumlah.MinimumWidth = 6;
            jumlah.Name = "jumlah";
            jumlah.Width = 125;
            // 
            // harga
            // 
            harga.HeaderText = "Harga";
            harga.MinimumWidth = 6;
            harga.Name = "harga";
            harga.Width = 125;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightGray;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(264, 148);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(302, 20);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LightGray;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(264, 186);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(302, 20);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.LightGray;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(264, 223);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(302, 20);
            textBox3.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.Transparent;
            dateTimePicker1.CalendarTitleBackColor = Color.Transparent;
            dateTimePicker1.CalendarTrailingForeColor = Color.Transparent;
            dateTimePicker1.Location = new Point(264, 259);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(302, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // V_TransaksiPelanggan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            Name = "V_TransaksiPelanggan";
            Size = new Size(1426, 941);
            Load += V_TransaksiPelanggan_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id_barang;
        private DataGridViewTextBoxColumn nama_barang;
        private DataGridViewTextBoxColumn jumlah;
        private DataGridViewTextBoxColumn harga;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
    }
}
