
namespace QuanLyVLXD
{
    partial class frmtimkiemsanpham
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTKSP = new System.Windows.Forms.DataGridView();
            this.mavattu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenvattu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenkho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gianhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaxuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMavattu = new System.Windows.Forms.TextBox();
            this.txtTenvattu = new System.Windows.Forms.TextBox();
            this.txtMakho = new System.Windows.Forms.TextBox();
            this.txtTenkho = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTKSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(257, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = "TÌM KIẾM SẢN PHẨM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã vật tư:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên vật tư:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã kho:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên kho:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số lượng:";
            // 
            // dataGridViewTKSP
            // 
            this.dataGridViewTKSP.AllowUserToAddRows = false;
            this.dataGridViewTKSP.AllowUserToDeleteRows = false;
            this.dataGridViewTKSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTKSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mavattu,
            this.tenvattu,
            this.makho,
            this.tenkho,
            this.soluong,
            this.gianhap,
            this.giaxuat});
            this.dataGridViewTKSP.Location = new System.Drawing.Point(42, 194);
            this.dataGridViewTKSP.Name = "dataGridViewTKSP";
            this.dataGridViewTKSP.ReadOnly = true;
            this.dataGridViewTKSP.Size = new System.Drawing.Size(746, 150);
            this.dataGridViewTKSP.TabIndex = 11;
            // 
            // mavattu
            // 
            this.mavattu.DataPropertyName = "mavattu";
            this.mavattu.HeaderText = "Mã vật tư";
            this.mavattu.Name = "mavattu";
            this.mavattu.ReadOnly = true;
            // 
            // tenvattu
            // 
            this.tenvattu.DataPropertyName = "tenvattu";
            this.tenvattu.HeaderText = "Tên vật tư";
            this.tenvattu.Name = "tenvattu";
            this.tenvattu.ReadOnly = true;
            // 
            // makho
            // 
            this.makho.DataPropertyName = "makho";
            this.makho.HeaderText = "Mã kho";
            this.makho.Name = "makho";
            this.makho.ReadOnly = true;
            // 
            // tenkho
            // 
            this.tenkho.DataPropertyName = "tenkho";
            this.tenkho.HeaderText = "Tên kho";
            this.tenkho.Name = "tenkho";
            this.tenkho.ReadOnly = true;
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "soluong";
            this.soluong.HeaderText = "Số lượng";
            this.soluong.Name = "soluong";
            this.soluong.ReadOnly = true;
            // 
            // gianhap
            // 
            this.gianhap.DataPropertyName = "gianhap";
            this.gianhap.HeaderText = "Giá nhập";
            this.gianhap.Name = "gianhap";
            this.gianhap.ReadOnly = true;
            // 
            // giaxuat
            // 
            this.giaxuat.DataPropertyName = "giaxuat";
            this.giaxuat.HeaderText = "Giá xuất";
            this.giaxuat.Name = "giaxuat";
            this.giaxuat.ReadOnly = true;
            // 
            // txtMavattu
            // 
            this.txtMavattu.Location = new System.Drawing.Point(105, 28);
            this.txtMavattu.Name = "txtMavattu";
            this.txtMavattu.Size = new System.Drawing.Size(137, 20);
            this.txtMavattu.TabIndex = 12;
            // 
            // txtTenvattu
            // 
            this.txtTenvattu.Location = new System.Drawing.Point(108, 66);
            this.txtTenvattu.Name = "txtTenvattu";
            this.txtTenvattu.Size = new System.Drawing.Size(134, 20);
            this.txtTenvattu.TabIndex = 13;
            // 
            // txtMakho
            // 
            this.txtMakho.Location = new System.Drawing.Point(311, 25);
            this.txtMakho.Name = "txtMakho";
            this.txtMakho.Size = new System.Drawing.Size(126, 20);
            this.txtMakho.TabIndex = 14;
            // 
            // txtTenkho
            // 
            this.txtTenkho.Location = new System.Drawing.Point(315, 66);
            this.txtTenkho.Name = "txtTenkho";
            this.txtTenkho.Size = new System.Drawing.Size(122, 20);
            this.txtTenkho.TabIndex = 15;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(547, 66);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(100, 20);
            this.txtSoluong.TabIndex = 16;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(140, 368);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(76, 37);
            this.btnTimkiem.TabIndex = 17;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnTimlai
            // 
            this.btnTimlai.Location = new System.Drawing.Point(370, 368);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(75, 37);
            this.btnTimlai.TabIndex = 18;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = true;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(573, 366);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 39);
            this.btnThoat.TabIndex = 19;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMavattu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSoluong);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenkho);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMakho);
            this.groupBox1.Controls.Add(this.txtTenvattu);
            this.groupBox1.Location = new System.Drawing.Point(78, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 101);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
            // 
            // frmtimkiemsanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.dataGridViewTKSP);
            this.Controls.Add(this.label5);
            this.Name = "frmtimkiemsanpham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm sản phẩm";
            this.Load += new System.EventHandler(this.frmtimkiemsanpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTKSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewTKSP;
        private System.Windows.Forms.TextBox txtMavattu;
        private System.Windows.Forms.TextBox txtTenvattu;
        private System.Windows.Forms.TextBox txtMakho;
        private System.Windows.Forms.TextBox txtTenkho;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn mavattu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenvattu;
        private System.Windows.Forms.DataGridViewTextBoxColumn makho;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenkho;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn gianhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaxuat;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}