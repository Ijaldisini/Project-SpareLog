namespace Project_SpareLog.View
{
    partial class V_TransaksiToko
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_TransaksiToko));
            dataGridView1 = new DataGridView();
            id_barang = new DataGridViewTextBoxColumn();
            nama_barang = new DataGridViewTextBoxColumn();
            jumlah_barang = new DataGridViewTextBoxColumn();
            harga = new DataGridViewTextBoxColumn();
            harga_toko = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id_barang, nama_barang, jumlah_barang, harga, harga_toko });
            dataGridView1.Location = new Point(23, 437);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1377, 386);
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
            // jumlah_barang
            // 
            jumlah_barang.HeaderText = "Jumlah Barang";
            jumlah_barang.MinimumWidth = 6;
            jumlah_barang.Name = "jumlah_barang";
            jumlah_barang.Width = 125;
            // 
            // harga
            // 
            harga.HeaderText = "Harga";
            harga.MinimumWidth = 6;
            harga.Name = "harga";
            harga.Width = 125;
            // 
            // harga_toko
            // 
            harga_toko.HeaderText = "Harga Toko";
            harga_toko.MinimumWidth = 6;
            harga_toko.Name = "harga_toko";
            harga_toko.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 281);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 1;
            label1.Text = "Nama Toko";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 346);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 2;
            label2.Text = "Tanggal";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(164, 278);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(164, 341);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1161, 830);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 5;
            label3.Text = "Total";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1253, 827);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(1289, 901);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Simpan";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // V_TransaksiToko
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "V_TransaksiToko";
            Size = new Size(1426, 941);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id_barang;
        private DataGridViewTextBoxColumn nama_barang;
        private DataGridViewTextBoxColumn jumlah_barang;
        private DataGridViewTextBoxColumn harga;
        private DataGridViewTextBoxColumn harga_toko;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private TextBox textBox2;
        private Button button1;
    }
}
