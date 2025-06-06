namespace Project_SpareLog.View
{
    partial class V_ManajemenStok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_ManajemenStok));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            id_barang = new DataGridViewTextBoxColumn();
            nama_barang = new DataGridViewTextBoxColumn();
            jumlah_stok = new DataGridViewTextBoxColumn();
            harga_jual = new DataGridViewTextBoxColumn();
            hpp = new DataGridViewTextBoxColumn();
            id_pemasok = new DataGridViewTextBoxColumn();
            tambah_stok = new DataGridViewButtonColumn();
            hapus = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(218, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1189, 24);
            button1.Name = "button1";
            button1.Size = new Size(218, 56);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_barang, nama_barang, jumlah_stok, harga_jual, hpp, id_pemasok, tambah_stok, hapus });
            dataGridView1.GridColor = Color.DarkGray;
            dataGridView1.Location = new Point(22, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1385, 758);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            // jumlah_stok
            // 
            jumlah_stok.HeaderText = "Jumlah Stok";
            jumlah_stok.MinimumWidth = 6;
            jumlah_stok.Name = "jumlah_stok";
            jumlah_stok.ReadOnly = true;
            jumlah_stok.Width = 125;
            // 
            // harga_jual
            // 
            harga_jual.HeaderText = "Harga Jual";
            harga_jual.MinimumWidth = 6;
            harga_jual.Name = "harga_jual";
            harga_jual.ReadOnly = true;
            harga_jual.Width = 125;
            // 
            // hpp
            // 
            hpp.HeaderText = "HPP";
            hpp.MinimumWidth = 6;
            hpp.Name = "hpp";
            hpp.ReadOnly = true;
            hpp.Width = 125;
            // 
            // id_pemasok
            // 
            id_pemasok.HeaderText = "ID Pemasok";
            id_pemasok.MinimumWidth = 6;
            id_pemasok.Name = "id_pemasok";
            id_pemasok.ReadOnly = true;
            id_pemasok.Width = 125;
            // 
            // tambah_stok
            // 
            tambah_stok.HeaderText = "";
            tambah_stok.MinimumWidth = 6;
            tambah_stok.Name = "tambah_stok";
            tambah_stok.Resizable = DataGridViewTriState.True;
            tambah_stok.SortMode = DataGridViewColumnSortMode.Automatic;
            tambah_stok.Width = 125;
            // 
            // hapus
            // 
            hapus.HeaderText = "";
            hapus.MinimumWidth = 6;
            hapus.Name = "hapus";
            hapus.Resizable = DataGridViewTriState.True;
            hapus.SortMode = DataGridViewColumnSortMode.Automatic;
            hapus.Width = 125;
            // 
            // V_ManajemenStok
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            Name = "V_ManajemenStok";
            Size = new Size(1426, 941);
            Load += V_ManajemenStok_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id_barang;
        private DataGridViewTextBoxColumn nama_barang;
        private DataGridViewTextBoxColumn jumlah_stok;
        private DataGridViewTextBoxColumn harga_jual;
        private DataGridViewTextBoxColumn hpp;
        private DataGridViewTextBoxColumn id_pemasok;
        private DataGridViewButtonColumn tambah_stok;
        private DataGridViewButtonColumn hapus;
    }
}
