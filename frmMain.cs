using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyVLXD;
using frmDVT;

namespace QuanLyXayDung
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
       

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhacungcap f = new frmNhacungcap();
            f.ShowDialog();
        }
     

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCongviec f = new frmCongviec();
            f.ShowDialog();
        }

        private void chiTiếtKhoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChitietkhohang f = new frmChitietkhohang();
            f.ShowDialog();
        }

        private void vậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVatTu f = new frmVatTu();
            if (btnTaikhoan.Visible == true)
            {
                f.txtgianhap.Visible = true;
                f.txtgiaxuat.Visible = true;
                f.ShowDialog();
            }
            else
            {
                f.txtgianhap.ReadOnly = true;
                f.txtgiaxuat.ReadOnly = true;
                f.ShowDialog();
            }           
        }

        private void đơnVịTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonvitinh f = new frmDonvitinh();
            f.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmkhachhang f = new frmkhachhang();
            f.ShowDialog();
        }

        private void khoHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmkhohang f = new frmkhohang();
            f.ShowDialog();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmnhanvien f = new frmnhanvien();
            f.ShowDialog();
        }

        private void btnTaikhoan_Click(object sender, EventArgs e)
        {
            FrmDanhsachTK f = new FrmDanhsachTK();
            f.ShowDialog();
        }

        private void hóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonXuat f = new frmHoaDonXuat();           

            if (btnTaikhoan.Visible == true)
            {
                f.btnTimkiem.Visible = true;
                f.lbMahoadonxuat.Visible = true;
                f.cbMahoadon.Visible = true;
                f.ShowDialog();
            }
            else
            {
                f.btnTimkiem.Visible = false;
                f.lbMahoadonxuat.Visible = false;
                f.cbMahoadon.Visible = false;
                f.ShowDialog();
            }
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonNhap f = new frmHoaDonNhap();

            if (btnTaikhoan.Visible == true)
            {
                f.btnTimkiem.Visible = true;
                f.lbMahoadonxuat.Visible = true;
                f.cbMahoadon.Visible = true;
                f.ShowDialog();
            }
            else
            {
                f.btnTimkiem.Visible = false;
                f.lbMahoadonxuat.Visible = false;
                f.cbMahoadon.Visible = false;
                f.ShowDialog();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DAO.openconnection();
        }

        private void tìmHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimHoaDonNhap f = new TimHoaDonNhap();
            f.ShowDialog();
        }

        private void btnDoitaikhoan_Click(object sender, EventArgs e)
        {
            frmDangnhap f = new frmDangnhap();
            this.Hide();
            f.ShowDialog();         
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?","Thôn báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void báoCáoHàngTồnKhoTheoQuýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoTonKho f = new BaoCaoTonKho();
            f.ShowDialog();
        }

        private void báoCáoVậtTưTrongKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BTL_QLBH.Forms.frmbaocaokho f = new BTL_QLBH.Forms.frmbaocaokho();
            f.ShowDialog();
        }

        private void tìmKiếmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtimkiemsanpham f = new frmtimkiemsanpham();
            f.ShowDialog();
        }

        private void báoCáoHóaĐơnBánCủaKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoBanHang f = new BaoCaoBanHang();
            f.ShowDialog();
        }

        private void báoCáoTổngTiềnHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BTL_QLBH.Forms.frmbaocaohdnhap f = new BTL_QLBH.Forms.frmbaocaohdnhap();
            f.ShowDialog();
        }
    }
}
