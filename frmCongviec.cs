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
    public partial class frmCongviec : Form
    {
        DataTable tblCongviec;
        public frmCongviec()
        {
            InitializeComponent();
        }

        private void xoatextbox()                                      // Làm trắng hết textbox
        {
            txtMacv.Text = "";
            txtTencv.Text = "";
        }

        private void loaddulieu()                        // Load form
        {
            try
            {
                DAO.openconnection();
                string sql = "select * from tblCongviec";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                tblCongviec = new DataTable();
                mydata.Fill(tblCongviec);
                dgvCongviec.DataSource = tblCongviec;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCongviec_Load(object sender, EventArgs e)
        {
            loaddulieu();
            btnLuu.Enabled = false;
            txtMacv.Enabled = false;
        }

        private void dgvCongviec_Click(object sender, EventArgs e)
        {
            txtMacv.Text = dgvCongviec.CurrentRow.Cells[0].Value.ToString();
            txtTencv.Text = dgvCongviec.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xoatextbox();
            int tongds = tblCongviec.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "CV0001";
            }
            else
            {
                int so;
                ma = "CV";
                so = Convert.ToInt32(tblCongviec.Rows[tongds - 1][0].ToString().Substring(2, 5));
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
            txtMacv.Text = ma;
            btnThem.Enabled = false;         
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            dgvCongviec.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblCongviec.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql;
            if (txtMacv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Thao tác không thể phục hồi, bạn chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblCongviec WHERE macv = N'" + txtMacv.Text + "'";
                DAO.chaylenhdelete(sql);
                loaddulieu();
                xoatextbox();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblCongviec.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMacv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn một bản ghi để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTencv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTencv.Focus();
                return;
            }

            string sql;
            sql = "update tblCongviec set tencongviec = N'" + txtTencv.Text.Trim() + "'where macv = N'" + txtMacv.Text + "'";
            DAO.chaylenh(sql);
            loaddulieu();
            xoatextbox();           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtTencv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên công việc", "Thông báo", MessageBoxButtons.OK);
                txtTencv.Focus();
                return;
            }
            string sql;
            sql = "insert into tblCongviec(macv, tencongviec) values (N'" + txtMacv.Text + "',  N'" + txtTencv.Text.Trim() + "')";
            DAO.chaylenh(sql);
            loaddulieu();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dgvCongviec.Enabled = true;
            btnLuu.Enabled = false;
            xoatextbox();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {           
            xoatextbox();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dgvCongviec.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();               
            }
        }

       
    }
}
