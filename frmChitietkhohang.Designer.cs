
namespace QuanLyVLXD
{
    partial class frmChitietkhohang
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
            this.dgvChitietkhohang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMavattu = new System.Windows.Forms.ComboBox();
            this.cbMakho = new System.Windows.Forms.ComboBox();
            this.txtTenvattu = new System.Windows.Forms.TextBox();
            this.txtTenkho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnLamlai = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lbthongtin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChitietkhohang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChitietkhohang
            // 
            this.dgvChitietkhohang.AllowUserToAddRows = false;
            this.dgvChitietkhohang.AllowUserToDeleteRows = false;
            this.dgvChitietkhohang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChitietkhohang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvChitietkhohang.Location = new System.Drawing.Point(66, 212);
            this.dgvChitietkhohang.Name = "dgvChitietkhohang";
            this.dgvChitietkhohang.ReadOnly = true;
            this.dgvChitietkhohang.Size = new System.Drawing.Size(645, 150);
            this.dgvChitietkhohang.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "makho";
            this.Column1.HeaderText = "Mã kho";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tenkho";
            this.Column2.HeaderText = "Tên kho";
            this.Column2.MinimumWidth = 200;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tenvattu";
            this.Column3.HeaderText = "Tên vật tư";
            this.Column3.MinimumWidth = 200;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "soluong";
            this.Column4.HeaderText = "Số lượng";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMavattu);
            this.groupBox1.Controls.Add(this.cbMakho);
            this.groupBox1.Controls.Add(this.txtTenvattu);
            this.groupBox1.Controls.Add(this.txtTenkho);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(66, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 111);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
            // 
            // cbMavattu
            // 
            this.cbMavattu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMavattu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMavattu.FormattingEnabled = true;
            this.cbMavattu.Location = new System.Drawing.Point(502, 24);
            this.cbMavattu.Name = "cbMavattu";
            this.cbMavattu.Size = new System.Drawing.Size(121, 21);
            this.cbMavattu.TabIndex = 6;
            this.cbMavattu.SelectedIndexChanged += new System.EventHandler(this.cbMavattu_SelectedIndexChanged);
            // 
            // cbMakho
            // 
            this.cbMakho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMakho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMakho.FormattingEnabled = true;
            this.cbMakho.Location = new System.Drawing.Point(102, 23);
            this.cbMakho.Name = "cbMakho";
            this.cbMakho.Size = new System.Drawing.Size(121, 21);
            this.cbMakho.TabIndex = 6;
            this.cbMakho.SelectedIndexChanged += new System.EventHandler(this.cbMakho_SelectedIndexChanged);
            // 
            // txtTenvattu
            // 
            this.txtTenvattu.Location = new System.Drawing.Point(102, 78);
            this.txtTenvattu.Name = "txtTenvattu";
            this.txtTenvattu.Size = new System.Drawing.Size(521, 20);
            this.txtTenvattu.TabIndex = 5;
            // 
            // txtTenkho
            // 
            this.txtTenkho.Location = new System.Drawing.Point(102, 52);
            this.txtTenkho.Name = "txtTenkho";
            this.txtTenkho.Size = new System.Drawing.Size(521, 20);
            this.txtTenkho.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tên vật tư:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã vật tư:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên kho:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã kho:";
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTimkiem.Location = new System.Drawing.Point(53, 24);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(75, 29);
            this.btnTimkiem.TabIndex = 12;
            this.btnTimkiem.Text = "&Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnLamlai
            // 
            this.btnLamlai.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLamlai.Location = new System.Drawing.Point(211, 24);
            this.btnLamlai.Name = "btnLamlai";
            this.btnLamlai.Size = new System.Drawing.Size(75, 29);
            this.btnLamlai.TabIndex = 12;
            this.btnLamlai.Text = "&Làm lại";
            this.btnLamlai.UseVisualStyleBackColor = true;
            this.btnLamlai.Click += new System.EventHandler(this.btnLamlai_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnLamlai);
            this.groupBox2.Controls.Add(this.btnTimkiem);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox2.Location = new System.Drawing.Point(152, 388);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 61);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // btnThoat
            // 
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(372, 24);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 29);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lbthongtin
            // 
            this.lbthongtin.AutoSize = true;
            this.lbthongtin.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbthongtin.Location = new System.Drawing.Point(551, 372);
            this.lbthongtin.Name = "lbthongtin";
            this.lbthongtin.Size = new System.Drawing.Size(0, 13);
            this.lbthongtin.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(263, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "CHI TIẾT KHO HÀNG";
            // 
            // frmChitietkhohang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbthongtin);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvChitietkhohang);
            this.Name = "frmChitietkhohang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết kho hàng";
            this.Load += new System.EventHandler(this.frmChitietkhohang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChitietkhohang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChitietkhohang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenvattu;
        private System.Windows.Forms.TextBox txtTenkho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMavattu;
        private System.Windows.Forms.ComboBox cbMakho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnLamlai;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lbthongtin;
        private System.Windows.Forms.Label label3;
    }
}