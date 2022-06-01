using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QuanLyVLXD
{
    public partial class TimHoaDonNhap : Form
    {

        DataTable tbl;     
        public TimHoaDonNhap()
        {
            InitializeComponent();
        }

        private void frmTimHoaDonNhap_Load(object sender, EventArgs e)
        {
            DAO.Dodulieuvaocombo("select makho from tblkhohang ", cboMakho, "makho", "makho");
            DAO.Dodulieuvaocombo("select mavattu from tblvattu ", cboMavattu, "mavattu", "mavattu");
            cboMavattu.SelectedIndex = -1;
            cboMakho.SelectedIndex = -1;
            dtpNgaynhap.Visible = false;
            string sql = "select DISTINCT  a.mahoadon, a.ngaynhap, b.tenkho, c.tenncc, d.tennv, a.tongtien from tblnhapkho as a, tblkhohang as b, tblnhacungcap as c, " +
               "tblnhanvien as d, tblchitietnhapkho as f where a.makho = b.makho and a.mancc = c.mancc and a.manv = d.manv and a.mahoadon = f.mahoadon ";
            loaddgv(sql);
        }

        private void btnChonngay_Click(object sender, EventArgs e)
        {
            dtpNgaynhap.Visible = true;
        }

        private void btnHuychonngay_Click(object sender, EventArgs e)
        {
            dtpNgaynhap.Visible = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLamlai_Click(object sender, EventArgs e)
        {
            cboMavattu.SelectedIndex = -1;
            cboMakho.SelectedIndex = -1;
            dtpNgaynhap.Visible = false;
            string sql = "select DISTINCT  a.mahoadon, a.ngaynhap, b.tenkho, c.tenncc, d.tennv, a.tongtien from tblnhapkho as a, tblkhohang as b, tblnhacungcap as c, " +
               "tblnhanvien as d, tblchitietnhapkho as f where a.makho = b.makho and a.mancc = c.mancc and a.manv = d.manv and a.mahoadon = f.mahoadon ";
            loaddgv(sql);
        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql = "select DISTINCT  a.mahoadon, a.ngaynhap, b.tenkho, c.tenncc, d.tennv, a.tongtien from tblnhapkho as a, tblkhohang as b, tblnhacungcap as c, " +
               "tblnhanvien as d, tblchitietnhapkho as f where a.makho = b.makho and a.mancc = c.mancc and a.manv = d.manv and a.mahoadon = f.mahoadon ";
            if (cboMakho.SelectedIndex != -1)
            {
                sql = sql + "and a.makho = N'" + cboMakho.SelectedValue + "' ";
            }
            if (cboMavattu.SelectedIndex != -1)
            {
                sql = sql + " and f.mavattu = N'" + cboMavattu.SelectedValue + "'";
            }
            if (dtpNgaynhap.Visible == true)
            {
                sql = sql + " and a.ngaynhap  between '" + dtpNgaynhap.Text + " 00:00:00 AM' and '" + dtpNgaynhap.Text + " 11:59:59 PM'";
            }

            if (cboMakho.SelectedIndex == -1 && cboMavattu.SelectedIndex == -1 && dtpNgaynhap.Visible == false)
            {
                MessageBox.Show("Bạn phải có ít nhất một điều kiện để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMakho.Focus();
                return;
            }
            loaddgv(sql);
            if (tbl.Rows.Count >0)
            {
                MessageBox.Show("Có " + tbl.Rows.Count + " kết quả", "Thông báo");
            }
        }

        private void loaddgv(string sql)
        {
            try
            {
                DAO.openconnection();               
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                tbl = new DataTable();
                mydata.Fill(tbl);
                if (tbl.Rows.Count < 1)
                {
                    MessageBox.Show("Không có kết quả", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                dgvHoaDonNhap.DataSource = tbl;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoaDonNhap_DoubleClick(object sender, EventArgs e)
        {
            string mahoadon = dgvHoaDonNhap.CurrentRow.Cells[0].Value.ToString();
            frmHoaDonNhap f = new frmHoaDonNhap();
            f.txtMahoadonnhap.Text = mahoadon;          
            f.btnTimkiem.Visible = false;
            f.lbMahoadonxuat.Visible = false;
            f.cbMahoadon.Visible = false;
            f.btnthem.Enabled = false;
            f.btnHuyhoadon.Enabled = false;
            f.btnLamlai.Enabled = false;
            f.btnInhoadon.Enabled = true;
            f.ShowDialog();
        }
    }
}
