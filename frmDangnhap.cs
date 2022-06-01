using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyXayDung;

namespace QuanLyVLXD
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DAO.openconnection();
            DataTable tbl = new DataTable();
            string sql;
            if (txtTaikhoan.Text.Trim() == "")
            {
                lbThongbao.Text = "Bạn chưa nhập tài khoản";
                txtTaikhoan.Focus();
                return;
            }
            if (txtMatkhau.Text.Trim() == "")
            {
                lbThongbao.Text = "Bạn chưa nhập mật khẩu";
                txtMatkhau.Focus();
                return;
            }
            sql = "select matk, taikhoan , matkhau from tblTaikhoan where taikhoan = N'" + txtTaikhoan.Text.Trim() + "'";
            
            try
            {
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);               
                mydata.Fill(tbl);                                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (tbl.Rows.Count < 1)
            {
                lbThongbao.Text = "Tài khoản không chính xác";
                txtTaikhoan.Focus();
                return;
            }
            if (txtMatkhau.Text.Trim().ToString() != tbl.Rows[0][2].ToString().Trim())
            {
                lbThongbao.Text = "Mật khẩu không chính xác";
                txtMatkhau.Focus();
                return;
            }


            frmMain f = new frmMain();
            if (tbl.Rows[0][0].ToString().Trim() != "TK001")             // Tk001  đặt mặc định là tài khoản admin
            {
                f.btnTaikhoan.Visible = false;
                this.Hide();               
                f.ShowDialog();
            }
            else
            {
                f.btnTaikhoan.Visible = true;
                this.Hide();
                f.ShowDialog();
            }
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
