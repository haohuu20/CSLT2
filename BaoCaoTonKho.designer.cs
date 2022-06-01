
namespace QuanLyXayDung
{
    partial class BaoCaoTonKho
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
            this.btntaobaocao = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.btninbaocao = new System.Windows.Forms.Button();
            this.dg_Tonkho = new System.Windows.Forms.DataGridView();
            this.cboquybaocao = new System.Windows.Forms.ComboBox();
            this.lblquybaocao = new System.Windows.Forms.Label();
            this.lblnambaocao = new System.Windows.Forms.Label();
            this.txtnambaocao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tonkho)).BeginInit();
            this.SuspendLayout();
            // 
            // btntaobaocao
            // 
            this.btntaobaocao.Location = new System.Drawing.Point(73, 91);
            this.btntaobaocao.Name = "btntaobaocao";
            this.btntaobaocao.Size = new System.Drawing.Size(184, 51);
            this.btntaobaocao.TabIndex = 0;
            this.btntaobaocao.Text = "Tạo báo cáo";
            this.btntaobaocao.UseVisualStyleBackColor = true;
            this.btntaobaocao.Click += new System.EventHandler(this.btntaobaocao_Click);
            // 
            // btndong
            // 
            this.btndong.Location = new System.Drawing.Point(551, 200);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(184, 51);
            this.btndong.TabIndex = 1;
            this.btndong.Text = "Đóng";
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnhienthi
            // 
            this.btnhienthi.Location = new System.Drawing.Point(73, 200);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(184, 51);
            this.btnhienthi.TabIndex = 2;
            this.btnhienthi.Text = "Hiển thị";
            this.btnhienthi.UseVisualStyleBackColor = true;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // btninbaocao
            // 
            this.btninbaocao.Location = new System.Drawing.Point(551, 91);
            this.btninbaocao.Name = "btninbaocao";
            this.btninbaocao.Size = new System.Drawing.Size(184, 51);
            this.btninbaocao.TabIndex = 3;
            this.btninbaocao.Text = "In báo cáo";
            this.btninbaocao.UseVisualStyleBackColor = true;
            this.btninbaocao.Click += new System.EventHandler(this.btninbaocao_Click);
            // 
            // dg_Tonkho
            // 
            this.dg_Tonkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Tonkho.Location = new System.Drawing.Point(73, 375);
            this.dg_Tonkho.Name = "dg_Tonkho";
            this.dg_Tonkho.Size = new System.Drawing.Size(662, 149);
            this.dg_Tonkho.TabIndex = 4;
            // 
            // cboquybaocao
            // 
            this.cboquybaocao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboquybaocao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboquybaocao.FormattingEnabled = true;
            this.cboquybaocao.Location = new System.Drawing.Point(168, 312);
            this.cboquybaocao.Name = "cboquybaocao";
            this.cboquybaocao.Size = new System.Drawing.Size(128, 21);
            this.cboquybaocao.TabIndex = 5;
            this.cboquybaocao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboquybaocao_KeyPress);
            // 
            // lblquybaocao
            // 
            this.lblquybaocao.AutoSize = true;
            this.lblquybaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblquybaocao.Location = new System.Drawing.Point(58, 311);
            this.lblquybaocao.Name = "lblquybaocao";
            this.lblquybaocao.Size = new System.Drawing.Size(97, 18);
            this.lblquybaocao.TabIndex = 6;
            this.lblquybaocao.Text = "Quý báo cáo:";
            // 
            // lblnambaocao
            // 
            this.lblnambaocao.AutoSize = true;
            this.lblnambaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnambaocao.Location = new System.Drawing.Point(484, 311);
            this.lblnambaocao.Name = "lblnambaocao";
            this.lblnambaocao.Size = new System.Drawing.Size(102, 18);
            this.lblnambaocao.TabIndex = 7;
            this.lblnambaocao.Text = "Năm báo cáo:";
            // 
            // txtnambaocao
            // 
            this.txtnambaocao.Location = new System.Drawing.Point(607, 309);
            this.txtnambaocao.Name = "txtnambaocao";
            this.txtnambaocao.Size = new System.Drawing.Size(128, 20);
            this.txtnambaocao.TabIndex = 8;
            this.txtnambaocao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnambaocao_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(244, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 31);
            this.label8.TabIndex = 130;
            this.label8.Text = "BÁO CÁO TỒN KHO";
            // 
            // BaoCaoTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 563);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtnambaocao);
            this.Controls.Add(this.lblnambaocao);
            this.Controls.Add(this.lblquybaocao);
            this.Controls.Add(this.cboquybaocao);
            this.Controls.Add(this.dg_Tonkho);
            this.Controls.Add(this.btninbaocao);
            this.Controls.Add(this.btnhienthi);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btntaobaocao);
            this.Name = "BaoCaoTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tồn kho";
            this.Load += new System.EventHandler(this.BaoCaoTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tonkho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntaobaocao;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnhienthi;
        private System.Windows.Forms.Button btninbaocao;
        private System.Windows.Forms.DataGridView dg_Tonkho;
        private System.Windows.Forms.ComboBox cboquybaocao;
        private System.Windows.Forms.Label lblquybaocao;
        private System.Windows.Forms.Label lblnambaocao;
        private System.Windows.Forms.TextBox txtnambaocao;
        private System.Windows.Forms.Label label8;
    }
}