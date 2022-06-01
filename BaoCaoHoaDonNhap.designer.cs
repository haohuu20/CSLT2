
namespace BTL_QLBH.Forms
{
    partial class frmbaocaohdnhap
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
            this.cbokhohang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnkiemtra = new System.Windows.Forms.Button();
            this.btnxuat = new System.Windows.Forms.Button();
            this.dgxuatbaocao = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btntimlai = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgxuatbaocao)).BeginInit();
            this.SuspendLayout();
            // 
            // cbokhohang
            // 
            this.cbokhohang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbokhohang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbokhohang.FormattingEnabled = true;
            this.cbokhohang.Location = new System.Drawing.Point(388, 176);
            this.cbokhohang.Name = "cbokhohang";
            this.cbokhohang.Size = new System.Drawing.Size(121, 21);
            this.cbokhohang.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kho nhập hàng:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnkiemtra
            // 
            this.btnkiemtra.Location = new System.Drawing.Point(142, 121);
            this.btnkiemtra.Name = "btnkiemtra";
            this.btnkiemtra.Size = new System.Drawing.Size(121, 32);
            this.btnkiemtra.TabIndex = 2;
            this.btnkiemtra.Text = "Kiểm tra";
            this.btnkiemtra.UseVisualStyleBackColor = true;
            this.btnkiemtra.Click += new System.EventHandler(this.btnkiemtra_Click);
            // 
            // btnxuat
            // 
            this.btnxuat.Location = new System.Drawing.Point(552, 121);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(121, 32);
            this.btnxuat.TabIndex = 3;
            this.btnxuat.Text = "Xuất Báo Cáo";
            this.btnxuat.UseVisualStyleBackColor = true;
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // dgxuatbaocao
            // 
            this.dgxuatbaocao.AllowUserToAddRows = false;
            this.dgxuatbaocao.AllowUserToDeleteRows = false;
            this.dgxuatbaocao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgxuatbaocao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.tongtien});
            this.dgxuatbaocao.Location = new System.Drawing.Point(28, 228);
            this.dgxuatbaocao.Name = "dgxuatbaocao";
            this.dgxuatbaocao.ReadOnly = true;
            this.dgxuatbaocao.Size = new System.Drawing.Size(760, 162);
            this.dgxuatbaocao.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "mahoadon";
            this.Column1.HeaderText = "Mã hóa đơn";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ngaynhap";
            this.Column2.HeaderText = "Ngày nhập";
            this.Column2.MinimumWidth = 120;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tenncc";
            this.Column3.HeaderText = "Tên nhà cũng cấp";
            this.Column3.MinimumWidth = 250;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "tennv";
            this.Column4.HeaderText = "Tên nhân viên";
            this.Column4.MinimumWidth = 150;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // tongtien
            // 
            this.tongtien.DataPropertyName = "tongtien";
            this.tongtien.HeaderText = "Tổng tiền";
            this.tongtien.MinimumWidth = 100;
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            // 
            // btntimlai
            // 
            this.btntimlai.Location = new System.Drawing.Point(142, 166);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(121, 31);
            this.btntimlai.TabIndex = 5;
            this.btntimlai.Text = "Tìm Lại";
            this.btntimlai.UseVisualStyleBackColor = true;
            this.btntimlai.Click += new System.EventHandler(this.btntimlai_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(552, 166);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(121, 31);
            this.btnthoat.TabIndex = 6;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(239, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(374, 31);
            this.label8.TabIndex = 131;
            this.label8.Text = "BÁO CÁO HÓA ĐƠN NHẬP";
            // 
            // frmbaocaohdnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.dgxuatbaocao);
            this.Controls.Add(this.btnxuat);
            this.Controls.Add(this.btnkiemtra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbokhohang);
            this.Name = "frmbaocaohdnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo hóa đơn nhập";
            this.Load += new System.EventHandler(this.frmbaocaohdnhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgxuatbaocao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbokhohang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnkiemtra;
        private System.Windows.Forms.Button btnxuat;
        private System.Windows.Forms.DataGridView dgxuatbaocao;
        private System.Windows.Forms.Button btntimlai;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
    }
}