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
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            textBox4 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            dateTimePicker1.ImeMode = ImeMode.NoControl;
            dateTimePicker1.Location = new Point(264, 259);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(302, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(22, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(436, 59);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
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
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = true;
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
            button2.TabIndex = 7;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.LightGray;
            textBox4.Location = new Point(1213, 776);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 8;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(75, 855);
            button4.Name = "button4";
            button4.Size = new Size(218, 56);
            button4.TabIndex = 19;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(316, 855);
            button3.Name = "button3";
            button3.Size = new Size(218, 56);
            button3.TabIndex = 20;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // V_TransaksiPelanggan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(textBox4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button4;
        private DataGridViewTextBoxColumn id_barang;
        private DataGridViewTextBoxColumn nama_barang;
        private DataGridViewTextBoxColumn jumlah;
        private DataGridViewTextBoxColumn harga;
        private TextBox textBox4;
        private Button button5;
        private Button button3;
        //private Button button3;
    }
}
