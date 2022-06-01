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
    public partial class FrmDanhsachTK : Form
    {
        DataTable tblTaikhoan;
        public FrmDanhsachTK()
        {
            InitializeComponent();
        }

        private void loaddulieu()                        // Load form
        {
            try
            {
                DAO.openconnection();
                string sql = "select * from tbltaikhoan order by matk asc";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                tblTaikhoan = new DataTable();
                mydata.Fill(tblTaikhoan);
                dgvTaikhoan.DataSource = tblTaikhoan;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoatextbox()                                      // Làm trắng hết textbox
        {
            txtMatk.Text = "";
            txtTentk.Text = "";
            txtGhichu.Text = "";
            txtMatkhau.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xoatextbox();
            txtTentk.ReadOnly = false;
            int tongds = tblTaikhoan.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "TK001";
            }
            else
            {
                int so;
                ma = "TK";
                so = Convert.ToInt32(tblTaikhoan.Rows[tongds - 1][0].ToString().Substring(2, 4));
                so = so + 1;
                if (so < 10)
                {
                    ma = ma + "00";
                }
                else if (so < 100)
                {
                    ma = ma + "0";
                }               
                ma = ma + so.ToString();
            }
            txtMatk.Text = ma;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            dgvTaikhoan.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void FrmDanhsachTK_Load(object sender, EventArgs e)
        {
            loaddulieu();
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xoatextbox();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dgvTaikhoan.Enabled = true;
            btnLuu.Enabled = false;
            txtTentk.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblTaikhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql;
            if (txtMatk.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn tài khoản nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtMatk.Text.Trim() == "TK001")
            {
                MessageBox.Show("Đây là tài khoản Admin không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Thao tác không thể phục hồi, bạn chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblTaikhoan WHERE matk = N'" + txtMatk.Text.Trim() + "'";
                DAO.chaylenhdelete(sql);
                loaddulieu();
                xoatextbox();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblTaikhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatk.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn một bản ghi để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (txtTentk.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentk.Focus();
                return;
            }           

            if (txtMatkhau.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatkhau.Focus();
                return;
            }

            if (DAO.kiemtrakhoachinh("select taikhoan from tbltaikhoan where taikhoan = N'" + txtTentk.Text.Trim() + "'"))
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại, hãy chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentk.Focus();
                return;
            }         

            string sql;
            sql = "update tblTaikhoan set matkhau = N'" + txtMatkhau.Text.Trim() +
                "', ghichu = N'" + txtGhichu.Text.Trim() + "' where matk = N'" + txtMatk.Text.Trim() + "' and taikhoan = N'" + txtTentk.Text.Trim() + "'";
            DAO.chaylenh(sql);
            loaddulieu();
            xoatextbox();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTentk.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK);
                txtTentk.Focus();
                return;
            }
            
            if (txtMatkhau.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK);
                txtMatkhau.Focus();
                return;
            }

            if (DAO.kiemtrakhoachinh("select taikhoan from tbltaikhoan where taikhoan = N'" + txtTentk.Text.Trim() + "'"))
            {
                MessageBox.Show("Tên tài khoản này đã tồn tại, hãy chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentk.Text = "";
                txtTentk.Focus();
                return;
            }
       
            string sql;
            sql = "insert into tbltaikhoan(matk, taikhoan, matkhau, ghichu) " +
            "values (N'" + txtMatk.Text.Trim() + "',  N'" + txtTentk.Text.Trim() + "', '" + txtMatkhau.Text.Trim() + "', N'" + txtGhichu.Text.Trim() + "')";
            DAO.chaylenh(sql);
            loaddulieu();
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            dgvTaikhoan.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtTentk.ReadOnly = true;
            xoatextbox();
        }

        private void dgvTaikhoan_Click(object sender, EventArgs e)
        {
            txtMatk.Text = dgvTaikhoan.CurrentRow.Cells[0].Value.ToString();
            txtTentk.Text = dgvTaikhoan.CurrentRow.Cells[1].Value.ToString();
            txtMatkhau.Text = dgvTaikhoan.CurrentRow.Cells[2].Value.ToString();
            txtGhichu.Text = dgvTaikhoan.CurrentRow.Cells[3].Value.ToString();
            txtMatk.Enabled = false;
        }
    }
}
