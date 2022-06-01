
namespace QuanLyXayDung
{
    partial class frmVatTu
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
            this.lblmavattu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmavattu = new System.Windows.Forms.TextBox();
            this.txttenvattu = new System.Windows.Forms.TextBox();
            this.txtgianhap = new System.Windows.Forms.TextBox();
            this.txtgiaxuat = new System.Windows.Forms.TextBox();
            this.cbomadonvitinh = new System.Windows.Forms.ComboBox();
            this.cbomancc = new System.Windows.Forms.ComboBox();
            this.dgvattu = new System.Windows.Forms.DataGridView();
            this.mavattu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenvattu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.madonvitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mancc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaxuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gianhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndong = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvattu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblmavattu
            // 
            this.lblmavattu.AutoSize = true;
            this.lblmavattu.Location = new System.Drawing.Point(55, 87);
            this.lblmavattu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmavattu.Name = "lblmavattu";
            this.lblmavattu.Size = new System.Drawing.Size(55, 13);
            this.lblmavattu.TabIndex = 2;
            this.lblmavattu.Text = "Mã vật tư:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên vật tư:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đơn vị tính:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giá nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giá xuất:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nhà cung cấp:";
            // 
            // txtmavattu
            // 
            this.txtmavattu.Location = new System.Drawing.Point(135, 86);
            this.txtmavattu.Margin = new System.Windows.Forms.Padding(2);
            this.txtmavattu.Name = "txtmavattu";
            this.txtmavattu.Size = new System.Drawing.Size(124, 20);
            this.txtmavattu.TabIndex = 8;
            // 
            // txttenvattu
            // 
            this.txttenvattu.Location = new System.Drawing.Point(386, 86);
            this.txttenvattu.Margin = new System.Windows.Forms.Padding(2);
            this.txttenvattu.Name = "txttenvattu";
            this.txttenvattu.Size = new System.Drawing.Size(124, 20);
            this.txttenvattu.TabIndex = 9;
            // 
            // txtgianhap
            // 
            this.txtgianhap.Location = new System.Drawing.Point(386, 157);
            this.txtgianhap.Margin = new System.Windows.Forms.Padding(2);
            this.txtgianhap.Name = "txtgianhap";
            this.txtgianhap.Size = new System.Drawing.Size(124, 20);
            this.txtgianhap.TabIndex = 10;
            this.txtgianhap.TextChanged += new System.EventHandler(this.txtgianhap_TextChanged);
            this.txtgianhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgianhap_KeyPress);
            // 
            // txtgiaxuat
            // 
            this.txtgiaxuat.Location = new System.Drawing.Point(135, 158);
            this.txtgiaxuat.Margin = new System.Windows.Forms.Padding(2);
            this.txtgiaxuat.Name = "txtgiaxuat";
            this.txtgiaxuat.Size = new System.Drawing.Size(124, 20);
            this.txtgiaxuat.TabIndex = 11;
            this.txtgiaxuat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgiaxuat_KeyPress);
            // 
            // cbomadonvitinh
            // 
            this.cbomadonvitinh.FormattingEnabled = true;
            this.cbomadonvitinh.Location = new System.Drawing.Point(135, 123);
            this.cbomadonvitinh.Margin = new System.Windows.Forms.Padding(2);
            this.cbomadonvitinh.Name = "cbomadonvitinh";
            this.cbomadonvitinh.Size = new System.Drawing.Size(124, 21);
            this.cbomadonvitinh.TabIndex = 12;
            // 
            // cbomancc
            // 
            this.cbomancc.FormattingEnabled = true;
            this.cbomancc.Location = new System.Drawing.Point(386, 123);
            this.cbomancc.Margin = new System.Windows.Forms.Padding(2);
            this.cbomancc.Name = "cbomancc";
            this.cbomancc.Size = new System.Drawing.Size(124, 21);
            this.cbomancc.TabIndex = 13;
            // 
            // dgvattu
            // 
            this.dgvattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvattu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mavattu,
            this.tenvattu,
            this.madonvitinh,
            this.mancc,
            this.giaxuat,
            this.gianhap});
            this.dgvattu.Location = new System.Drawing.Point(41, 197);
            this.dgvattu.Margin = new System.Windows.Forms.Padding(2);
            this.dgvattu.Name = "dgvattu";
            this.dgvattu.RowHeadersWidth = 51;
            this.dgvattu.RowTemplate.Height = 24;
            this.dgvattu.Size = new System.Drawing.Size(635, 167);
            this.dgvattu.TabIndex = 14;
            this.dgvattu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvattu_CellClick);
            // 
            // mavattu
            // 
            this.mavattu.DataPropertyName = "mavattu";
            this.mavattu.HeaderText = "Mã vật tư";
            this.mavattu.MinimumWidth = 6;
            this.mavattu.Name = "mavattu";
            this.mavattu.Width = 125;
            // 
            // tenvattu
            // 
            this.tenvattu.DataPropertyName = "tenvattu";
            this.tenvattu.HeaderText = "Tên vật tư";
            this.tenvattu.MinimumWidth = 6;
            this.tenvattu.Name = "tenvattu";
            this.tenvattu.Width = 125;
            // 
            // madonvitinh
            // 
            this.madonvitinh.DataPropertyName = "tendonvitinh";
            this.madonvitinh.HeaderText = "Đơn vị tính";
            this.madonvitinh.MinimumWidth = 6;
            this.madonvitinh.Name = "madonvitinh";
            this.madonvitinh.Width = 125;
            // 
            // mancc
            // 
            this.mancc.DataPropertyName = "tenncc";
            this.mancc.HeaderText = "Nhà cung cấp";
            this.mancc.MinimumWidth = 6;
            this.mancc.Name = "mancc";
            this.mancc.Width = 125;
            // 
            // giaxuat
            // 
            this.giaxuat.DataPropertyName = "giaxuat";
            this.giaxuat.HeaderText = "Giá xuất";
            this.giaxuat.MinimumWidth = 6;
            this.giaxuat.Name = "giaxuat";
            this.giaxuat.Width = 125;
            // 
            // gianhap
            // 
            this.gianhap.DataPropertyName = "gianhap";
            this.gianhap.HeaderText = "Giá nhập";
            this.gianhap.MinimumWidth = 6;
            this.gianhap.Name = "gianhap";
            this.gianhap.Width = 125;
            // 
            // btndong
            // 
            this.btndong.Location = new System.Drawing.Point(598, 383);
            this.btndong.Margin = new System.Windows.Forms.Padding(2);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(78, 33);
            this.btndong.TabIndex = 27;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(503, 383);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(78, 33);
            this.btnxoa.TabIndex = 26;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(407, 383);
            this.btnhuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(78, 33);
            this.btnhuy.TabIndex = 25;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(222, 383);
            this.btnluu.Margin = new System.Windows.Forms.Padding(2);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(78, 33);
            this.btnluu.TabIndex = 24;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(130, 383);
            this.btnthem.Margin = new System.Windows.Forms.Padding(2);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(78, 33);
            this.btnthem.TabIndex = 23;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(315, 383);
            this.btnsua.Margin = new System.Windows.Forms.Padding(2);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(78, 33);
            this.btnsua.TabIndex = 28;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(41, 383);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(75, 33);
            this.btnTimkiem.TabIndex = 29;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(305, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 31);
            this.label6.TabIndex = 30;
            this.label6.Text = "VẬT TƯ";
            // 
            // frmVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 460);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.dgvattu);
            this.Controls.Add(this.cbomancc);
            this.Controls.Add(this.cbomadonvitinh);
            this.Controls.Add(this.txtgiaxuat);
            this.Controls.Add(this.txtgianhap);
            this.Controls.Add(this.txttenvattu);
            this.Controls.Add(this.txtmavattu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblmavattu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmVatTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vattu";
            this.Load += new System.EventHandler(this.frmVatTu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvattu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblmavattu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmavattu;
        private System.Windows.Forms.TextBox txttenvattu;
        private System.Windows.Forms.ComboBox cbomadonvitinh;
        private System.Windows.Forms.ComboBox cbomancc;
        private System.Windows.Forms.DataGridView dgvattu;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.DataGridViewTextBoxColumn mavattu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenvattu;
        private System.Windows.Forms.DataGridViewTextBoxColumn madonvitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn mancc;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaxuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn gianhap;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtgianhap;
        public System.Windows.Forms.TextBox txtgiaxuat;
    }
}