
namespace QuanLyVLXD
{
    partial class frmkhohang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMakho = new System.Windows.Forms.TextBox();
            this.txtTenkho = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtDientich = new System.Windows.Forms.TextBox();
            this.dataGridViewKhohang = new System.Windows.Forms.DataGridView();
            this.makho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenkho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dienthoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dientich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cboManv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhohang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã kho:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên kho:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã nhân viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số điện thoại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(556, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Diện tích:";
            // 
            // txtMakho
            // 
            this.txtMakho.Location = new System.Drawing.Point(139, 75);
            this.txtMakho.Name = "txtMakho";
            this.txtMakho.Size = new System.Drawing.Size(124, 20);
            this.txtMakho.TabIndex = 8;
            // 
            // txtTenkho
            // 
            this.txtTenkho.Location = new System.Drawing.Point(139, 113);
            this.txtTenkho.Name = "txtTenkho";
            this.txtTenkho.Size = new System.Drawing.Size(124, 20);
            this.txtTenkho.TabIndex = 9;
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(401, 113);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(124, 20);
            this.txtSdt.TabIndex = 11;
            this.txtSdt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSdt_KeyPress);
            // 
            // txtDientich
            // 
            this.txtDientich.Location = new System.Drawing.Point(613, 75);
            this.txtDientich.Name = "txtDientich";
            this.txtDientich.Size = new System.Drawing.Size(124, 20);
            this.txtDientich.TabIndex = 12;
            this.txtDientich.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDientich_KeyPress);
            // 
            // dataGridViewKhohang
            // 
            this.dataGridViewKhohang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhohang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.makho,
            this.tenkho,
            this.manv,
            this.dienthoai,
            this.dientich});
            this.dataGridViewKhohang.Location = new System.Drawing.Point(123, 156);
            this.dataGridViewKhohang.Name = "dataGridViewKhohang";
            this.dataGridViewKhohang.Size = new System.Drawing.Size(545, 186);
            this.dataGridViewKhohang.TabIndex = 13;
            this.dataGridViewKhohang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKhohang_CellClick);
            // 
            // makho
            // 
            this.makho.DataPropertyName = "makho";
            this.makho.HeaderText = "Mã kho";
            this.makho.Name = "makho";
            // 
            // tenkho
            // 
            this.tenkho.DataPropertyName = "tenkho";
            this.tenkho.HeaderText = "Tên kho";
            this.tenkho.Name = "tenkho";
            // 
            // manv
            // 
            this.manv.DataPropertyName = "manv";
            this.manv.HeaderText = "Mã nhân viên";
            this.manv.Name = "manv";
            // 
            // dienthoai
            // 
            this.dienthoai.DataPropertyName = "dienthoai";
            this.dienthoai.HeaderText = "Số điện thoại";
            this.dienthoai.Name = "dienthoai";
            // 
            // dientich
            // 
            this.dientich.DataPropertyName = "dientich";
            this.dientich.HeaderText = "Diện tích";
            this.dientich.Name = "dientich";
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(51, 370);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(75, 29);
            this.btnTimkiem.TabIndex = 15;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(158, 370);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 29);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(271, 370);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 29);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(389, 370);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 29);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(503, 370);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 29);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(602, 370);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 29);
            this.btnHuy.TabIndex = 20;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(703, 370);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 29);
            this.btnThoat.TabIndex = 21;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cboManv
            // 
            this.cboManv.FormattingEnabled = true;
            this.cboManv.Location = new System.Drawing.Point(402, 75);
            this.cboManv.Name = "cboManv";
            this.cboManv.Size = new System.Drawing.Size(121, 21);
            this.cboManv.TabIndex = 22;
            this.cboManv.TextChanged += new System.EventHandler(this.cboManv_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(327, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "KHO HÀNG";
            // 
            // frmkhohang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboManv);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.dataGridViewKhohang);
            this.Controls.Add(this.txtDientich);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.txtTenkho);
            this.Controls.Add(this.txtMakho);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmkhohang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho hàng";
            this.Load += new System.EventHandler(this.frmkhohang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhohang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMakho;
        private System.Windows.Forms.TextBox txtTenkho;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtDientich;
        private System.Windows.Forms.DataGridView dataGridViewKhohang;
        private System.Windows.Forms.DataGridViewTextBoxColumn makho;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenkho;
        private System.Windows.Forms.DataGridViewTextBoxColumn manv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dienthoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dientich;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cboManv;
        private System.Windows.Forms.Label label2;
    }
}