namespace Project_SpareLog.View
{
    partial class V_RTToko
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_RTToko));
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            id_transaksi = new DataGridViewTextBoxColumn();
            tanggal_transaksi = new DataGridViewTextBoxColumn();
            id_pelanggan = new DataGridViewTextBoxColumn();
            id_barang = new DataGridViewTextBoxColumn();
            jumlah = new DataGridViewTextBoxColumn();
            harga = new DataGridViewTextBoxColumn();
            harga_diskon = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.LightGray;
            textBox2.Location = new Point(1213, 830);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 26;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.Transparent;
            dateTimePicker1.CalendarTitleBackColor = Color.Transparent;
            dateTimePicker1.CalendarTrailingForeColor = Color.Transparent;
            dateTimePicker1.ImeMode = ImeMode.NoControl;
            dateTimePicker1.Location = new Point(264, 259);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(302, 27);
            dateTimePicker1.TabIndex = 25;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.LightGray;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(264, 223);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(302, 20);
            textBox1.TabIndex = 24;
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
            button2.TabIndex = 23;
            button2.UseVisualStyleBackColor = true;
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
            button1.TabIndex = 22;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Location = new Point(22, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(505, 59);
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_transaksi, tanggal_transaksi, id_pelanggan, id_barang, jumlah, harga, harga_diskon });
            dataGridView1.Location = new Point(83, 324);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1255, 500);
            dataGridView1.TabIndex = 20;
            // 
            // id_transaksi
            // 
            id_transaksi.HeaderText = "ID Transaksi";
            id_transaksi.MinimumWidth = 6;
            id_transaksi.Name = "id_transaksi";
            id_transaksi.ReadOnly = true;
            id_transaksi.Width = 125;
            // 
            // tanggal_transaksi
            // 
            tanggal_transaksi.HeaderText = "Tanggal Transaksi";
            tanggal_transaksi.MinimumWidth = 6;
            tanggal_transaksi.Name = "tanggal_transaksi";
            tanggal_transaksi.ReadOnly = true;
            tanggal_transaksi.Width = 125;
            // 
            // id_pelanggan
            // 
            id_pelanggan.HeaderText = "ID Pelanggan";
            id_pelanggan.MinimumWidth = 6;
            id_pelanggan.Name = "id_pelanggan";
            id_pelanggan.ReadOnly = true;
            id_pelanggan.Width = 125;
            // 
            // id_barang
            // 
            id_barang.HeaderText = "ID Barang";
            id_barang.MinimumWidth = 6;
            id_barang.Name = "id_barang";
            id_barang.ReadOnly = true;
            id_barang.Width = 125;
            // 
            // jumlah
            // 
            jumlah.HeaderText = "Jumlah";
            jumlah.MinimumWidth = 6;
            jumlah.Name = "jumlah";
            jumlah.ReadOnly = true;
            jumlah.Width = 125;
            // 
            // harga
            // 
            harga.HeaderText = "Harga";
            harga.MinimumWidth = 6;
            harga.Name = "harga";
            harga.ReadOnly = true;
            harga.Width = 125;
            // 
            // harga_diskon
            // 
            harga_diskon.HeaderText = "Harga Diskon";
            harga_diskon.MinimumWidth = 6;
            harga_diskon.Name = "harga_diskon";
            harga_diskon.ReadOnly = true;
            harga_diskon.Width = 125;
            // 
            // V_RTToko
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(textBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            DoubleBuffered = true;
            Name = "V_RTToko";
            Size = new Size(1426, 941);
            Load += V_RTToko_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id_transaksi;
        private DataGridViewTextBoxColumn tanggal_transaksi;
        private DataGridViewTextBoxColumn id_pelanggan;
        private DataGridViewTextBoxColumn id_barang;
        private DataGridViewTextBoxColumn jumlah;
        private DataGridViewTextBoxColumn harga;
        private DataGridViewTextBoxColumn harga_diskon;
    }
}
