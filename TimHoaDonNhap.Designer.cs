
namespace QuanLyVLXD
{
    partial class TimHoaDonNhap
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
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnLamlai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvHoaDonNhap = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHuychonngay = new System.Windows.Forms.Button();
            this.btnChonngay = new System.Windows.Forms.Button();
            this.dtpNgaynhap = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMakho = new System.Windows.Forms.ComboBox();
            this.cboMavattu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(142, 395);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(84, 39);
            this.btnTimkiem.TabIndex = 6;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnLamlai
            // 
            this.btnLamlai.Location = new System.Drawing.Point(303, 395);
            this.btnLamlai.Name = "btnLamlai";
            this.btnLamlai.Size = new System.Drawing.Size(84, 39);
            this.btnLamlai.TabIndex = 6;
            this.btnLamlai.Text = "Làm lại";
            this.btnLamlai.UseVisualStyleBackColor = true;
            this.btnLamlai.Click += new System.EventHandler(this.btnLamlai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(458, 395);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 39);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvHoaDonNhap
            // 
            this.dgvHoaDonNhap.AllowUserToAddRows = false;
            this.dgvHoaDonNhap.AllowUserToDeleteRows = false;
            this.dgvHoaDonNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvHoaDonNhap.Location = new System.Drawing.Point(45, 219);
            this.dgvHoaDonNhap.Name = "dgvHoaDonNhap";
            this.dgvHoaDonNhap.ReadOnly = true;
            this.dgvHoaDonNhap.Size = new System.Drawing.Size(628, 150);
            this.dgvHoaDonNhap.TabIndex = 7;
            this.dgvHoaDonNhap.DoubleClick += new System.EventHandler(this.dgvHoaDonNhap_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "mahoadon";
            this.Column1.HeaderText = "Mã hóa đơn";
            this.Column1.MinimumWidth = 60;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "ngaynhap";
            this.Column6.HeaderText = "Ngày nhập";
            this.Column6.MinimumWidth = 130;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tenkho";
            this.Column2.HeaderText = "Tên kho";
            this.Column2.MinimumWidth = 90;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tenncc";
            this.Column3.HeaderText = "Tên nhà cung cấp";
            this.Column3.MinimumWidth = 250;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "tennv";
            this.Column4.HeaderText = "Tên nhân viên";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "tongtien";
            this.Column5.HeaderText = "Tổng tiền";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboMavattu);
            this.groupBox1.Controls.Add(this.cboMakho);
            this.groupBox1.Controls.Add(this.btnHuychonngay);
            this.groupBox1.Controls.Add(this.btnChonngay);
            this.groupBox1.Controls.Add(this.dtpNgaynhap);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(142, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 105);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
            // 
            // btnHuychonngay
            // 
            this.btnHuychonngay.Location = new System.Drawing.Point(334, 71);
            this.btnHuychonngay.Name = "btnHuychonngay";
            this.btnHuychonngay.Size = new System.Drawing.Size(66, 23);
            this.btnHuychonngay.TabIndex = 5;
            this.btnHuychonngay.Text = "Hủy chọn";
            this.btnHuychonngay.UseVisualStyleBackColor = true;
            this.btnHuychonngay.Click += new System.EventHandler(this.btnHuychonngay_Click);
            // 
            // btnChonngay
            // 
            this.btnChonngay.Location = new System.Drawing.Point(126, 72);
            this.btnChonngay.Name = "btnChonngay";
            this.btnChonngay.Size = new System.Drawing.Size(66, 23);
            this.btnChonngay.TabIndex = 5;
            this.btnChonngay.Text = "Chọn ngày";
            this.btnChonngay.UseVisualStyleBackColor = true;
            this.btnChonngay.Click += new System.EventHandler(this.btnChonngay_Click);
            // 
            // dtpNgaynhap
            // 
            this.dtpNgaynhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaynhap.Location = new System.Drawing.Point(214, 73);
            this.dtpNgaynhap.Name = "dtpNgaynhap";
            this.dtpNgaynhap.Size = new System.Drawing.Size(99, 20);
            this.dtpNgaynhap.TabIndex = 4;
            this.dtpNgaynhap.Value = new System.DateTime(2021, 11, 2, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã kho:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã vật tư:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(217, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "TÌM HÓA ĐƠN NHẬP";
            // 
            // cboMakho
            // 
            this.cboMakho.FormattingEnabled = true;
            this.cboMakho.Location = new System.Drawing.Point(118, 21);
            this.cboMakho.Name = "cboMakho";
            this.cboMakho.Size = new System.Drawing.Size(111, 21);
            this.cboMakho.TabIndex = 6;
            // 
            // cboMavattu
            // 
            this.cboMavattu.FormattingEnabled = true;
            this.cboMavattu.Location = new System.Drawing.Point(118, 49);
            this.cboMavattu.Name = "cboMavattu";
            this.cboMavattu.Size = new System.Drawing.Size(111, 21);
            this.cboMavattu.TabIndex = 7;
            // 
            // TimHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvHoaDonNhap);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLamlai);
            this.Controls.Add(this.btnTimkiem);
            this.Name = "TimHoaDonNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.frmTimHoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnLamlai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvHoaDonNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgaynhap;
        private System.Windows.Forms.Button btnHuychonngay;
        private System.Windows.Forms.Button btnChonngay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ComboBox cboMavattu;
        private System.Windows.Forms.ComboBox cboMakho;
    }
}