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
    public partial class frmNhacungcap : Form
    {
        DataTable tblNhacungcap;
        public frmNhacungcap()
        {
            InitializeComponent();
        }
        private void loaddulieu()                        // Load form
        {
            try
            {
                DAO.openconnection();
                string sql = "select * from tblNhacungcap";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                tblNhacungcap = new DataTable();
                mydata.Fill(tblNhacungcap);
                dgvNhacungcap.DataSource = tblNhacungcap;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lbThongtin.Text = "";
        }

        private void xoatextbox()                                      // Làm trắng hết textbox
        {
            txtMancc.Text = "";
            txtTenncc.Text = "";
            txtDienthoai.Text = "";
            txtDiachi.Text = "";
        }
        private void frmNhacungcap_Load(object sender, EventArgs e)
        {
            loaddulieu();
            btnLuu.Enabled = false;
        }


        private void dgvNhacungcap_Click(object sender, EventArgs e)
        {
            txtMancc.Text = dgvNhacungcap.CurrentRow.Cells[0].Value.ToString();
            txtTenncc.Text = dgvNhacungcap.CurrentRow.Cells[1].Value.ToString();
            txtDiachi.Text = dgvNhacungcap.CurrentRow.Cells[2].Value.ToString();
            txtDienthoai.Text = dgvNhacungcap.CurrentRow.Cells[3].Value.ToString();
            txtMancc.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            xoatextbox();
            int tongds = tblNhacungcap.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "NCC0001";
            }
            else
            {
                int so;
                ma = "NCC";
                so = Convert.ToInt32(tblNhacungcap.Rows[tongds - 1][0].ToString().Substring(3, 5));
                so = so + 1;
                if (so < 10)
                {
                    ma = ma + "000";
                }
                else if (so < 100)
                {
                    ma = ma + "00";
                }
                else if (so < 1000)
                {
                    ma = ma + "0";
                }
                ma = ma + so.ToString();
            }
            txtMancc.Text = ma;
            txtMancc.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvNhacungcap.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblNhacungcap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql;
            if (txtMancc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Thao tác không thể phục hồi, bạn chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblNhacungcap WHERE mancc = N'" + txtMancc.Text + "'";
                DAO.chaylenhdelete(sql);
                loaddulieu();
                xoatextbox();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblNhacungcap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMancc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn một bản ghi để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenncc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenncc.Focus();
                return;
            }
            if (txtDienthoai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienthoai.Focus();
                return;
            }
            if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }

            string sql;
            sql = "update tblNhacungcap set tenncc = N'" + txtTenncc.Text.Trim() + "', dienthoai = '" + txtDienthoai.Text.Trim() +
                "', diachi = N'" + txtDiachi.Text.Trim()+ "' where mancc = N'" + txtMancc.Text + "'";
            DAO.chaylenh(sql);
            loaddulieu();
            xoatextbox();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenncc.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK);
                txtTenncc.Focus();
                return;
            }
            if (txtDienthoai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK);
                txtDienthoai.Focus();
                return;
            }
            if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDiachi.Focus();
                return;
            }
            string sql;
            sql = "insert into tblNhacungcap(mancc, tenncc, diachi, dienthoai) " +
            "values (N'" + txtMancc.Text + "',  N'" + txtTenncc.Text.Trim() + "', '"+ txtDiachi.Text.Trim() + "', N'"+ txtDienthoai.Text.Trim() + "')" ;
            DAO.chaylenh(sql);
            loaddulieu();
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            dgvNhacungcap.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            xoatextbox();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loaddulieu();
            xoatextbox();
            btnThem.Enabled = true;
            dgvNhacungcap.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMancc.Enabled = true;
            lbThongtin.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtDienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (tblNhacungcap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "SELECT * FROM tblNhacungcap WHERE 1=1";

            if (txtMancc.Text.Trim() != "")
            {
                sql = sql + " and mancc Like '%" + txtMancc.Text.Trim() + "%'";
            }                  
            if (txtTenncc.Text.Trim() != "")
            {
                sql = sql + " and tenncc Like N'%" + txtTenncc.Text.Trim() + "%'"; 
            }                           
            if (txtDienthoai.Text.Trim() != "")
            {
                sql = sql + " and dienthoai Like '%" + txtDienthoai.Text.Trim() +"%'";
            }
            if (txtDiachi.Text.Trim() != "")
            {
                sql = sql + " and diachi Like N'%" + txtDiachi.Text.Trim() + "%'";
            }
            if (sql == "SELECT * FROM tblNhacungcap WHERE 1=1")
            {
                MessageBox.Show("Bạn phải có ít nhât một thông tin mới thực hiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMancc.Focus();
                return;
                
            }
            try
            {
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                DataTable tbl = new DataTable();
                mydata.Fill(tbl);
                if (tbl.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi nào phù thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    lbThongtin.Text = "Có " + tbl.Rows.Count + " thỏa mã điều kiện!";
                }
                dgvNhacungcap.DataSource = tbl;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
    }
}
