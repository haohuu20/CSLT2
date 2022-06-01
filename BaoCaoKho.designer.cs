
namespace BTL_QLBH.Forms
{
    partial class frmbaocaokho
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
            this.btnkiemtra = new System.Windows.Forms.Button();
            this.btntimlai = new System.Windows.Forms.Button();
            this.btnxuat = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.cbokhohang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgchitietkho = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgchitietkho)).BeginInit();
            this.SuspendLayout();
            // 
            // btnkiemtra
            // 
            this.btnkiemtra.Location = new System.Drawing.Point(139, 95);
            this.btnkiemtra.Name = "btnkiemtra";
            this.btnkiemtra.Size = new System.Drawing.Size(93, 30);
            this.btnkiemtra.TabIndex = 0;
            this.btnkiemtra.Text = "Kiểm Tra";
            this.btnkiemtra.UseVisualStyleBackColor = true;
            this.btnkiemtra.Click += new System.EventHandler(this.btnkiemtra_Click);
            // 
            // btntimlai
            // 
            this.btntimlai.Location = new System.Drawing.Point(139, 133);
            this.btntimlai.Name = "btntimlai";
            this.btntimlai.Size = new System.Drawing.Size(93, 30);
            this.btntimlai.TabIndex = 1;
            this.btntimlai.Text = "Tìm Lại";
            this.btntimlai.UseVisualStyleBackColor = true;
            this.btntimlai.Click += new System.EventHandler(this.btntimlai_Click);
            // 
            // btnxuat
            // 
            this.btnxuat.Location = new System.Drawing.Point(564, 95);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(93, 30);
            this.btnxuat.TabIndex = 2;
            this.btnxuat.Text = "Xuất Báo Cáo";
            this.btnxuat.UseVisualStyleBackColor = true;
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(564, 131);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(93, 30);
            this.btnthoat.TabIndex = 3;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // cbokhohang
            // 
            this.cbokhohang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbokhohang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbokhohang.FormattingEnabled = true;
            this.cbokhohang.Location = new System.Drawing.Point(367, 140);
            this.cbokhohang.Name = "cbokhohang";
            this.cbokhohang.Size = new System.Drawing.Size(121, 21);
            this.cbokhohang.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kho hàng:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgchitietkho
            // 
            this.dgchitietkho.AllowUserToAddRows = false;
            this.dgchitietkho.AllowUserToDeleteRows = false;
            this.dgchitietkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgchitietkho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgchitietkho.Location = new System.Drawing.Point(42, 200);
            this.dgchitietkho.Name = "dgchitietkho";
            this.dgchitietkho.ReadOnly = true;
            this.dgchitietkho.Size = new System.Drawing.Size(732, 189);
            this.dgchitietkho.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "mavattu";
            this.Column1.HeaderText = "Mã vật tư";
            this.Column1.MinimumWidth = 80;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tenvattu";
            this.Column2.HeaderText = "Tên vật tư";
            this.Column2.MinimumWidth = 150;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tendonvitinh";
            this.Column3.HeaderText = "Đơn vị tính";
            this.Column3.MinimumWidth = 80;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "soluong";
            this.Column4.HeaderText = "Sô lượng";
            this.Column4.MinimumWidth = 80;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "gianhap";
            this.Column5.HeaderText = "Giá nhập";
            this.Column5.MinimumWidth = 80;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "giaxuat";
            this.Column6.HeaderText = "Giá xuất";
            this.Column6.MinimumWidth = 80;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "mancc";
            this.Column7.HeaderText = "Mã NCC";
            this.Column7.MinimumWidth = 80;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(198, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(437, 31);
            this.label8.TabIndex = 130;
            this.label8.Text = "BÁO CÁO VẬT TƯ TRONG KHO";
            // 
            // frmbaocaokho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgchitietkho);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbokhohang);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxuat);
            this.Controls.Add(this.btntimlai);
            this.Controls.Add(this.btnkiemtra);
            this.Name = "frmbaocaokho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmbaocaokho";
            this.Load += new System.EventHandler(this.frmbaocaokho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgchitietkho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnkiemtra;
        private System.Windows.Forms.Button btntimlai;
        private System.Windows.Forms.Button btnxuat;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.ComboBox cbokhohang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgchitietkho;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}