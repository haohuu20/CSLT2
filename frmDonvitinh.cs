using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanLyVLXD;

namespace frmDVT
{
    public partial class frmDonvitinh : Form
    {

        private DataTable tbldonvitinh;
        public frmDonvitinh()
        {
            InitializeComponent();
        }

        private void xoatextbox()                                      // Làm trắng hết textbox
        {
            txtMadvt.Text = "";
            txtTendvt.Text = "";
        }
        private void loaddulieu()                        // Load form
        {
            try
            {
                DAO.openconnection();
                string sql = "select madonvitinh, tendonvitinh from tbldonvitinh";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                tbldonvitinh = new DataTable();
                mydata.Fill(tbldonvitinh);
                dgvDonvitinh.DataSource = tbldonvitinh;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xoatextbox();
            int tongds = tbldonvitinh.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "DVT001";
            }
            else
            {
                int so;
                ma = "DVT";
                so = Convert.ToInt32(tbldonvitinh.Rows[tongds - 1][0].ToString().Substring(3, 5));
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
            txtMadvt.Text = ma;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            dgvDonvitinh.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tbldonvitinh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql;
            if (txtMadvt.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Thao tác không thể phục hồi, bạn chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tbldonvitinh WHERE madonvitinh = N'" + txtMadvt.Text + "'";
                DAO.chaylenhdelete(sql);
                loaddulieu();
                xoatextbox();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tbldonvitinh.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMadvt.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn một bản ghi để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTendvt.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendvt.Focus();
                return;
            }

            string sql;
            sql = "update tbldonvitinh set tendonvitinh = N'" + txtTendvt.Text.Trim() + "'where madonvitinh = N'" + txtMadvt.Text + "'";
            DAO.chaylenh(sql);
            loaddulieu();
            xoatextbox();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTendvt.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đơn vị tính", "Thông báo", MessageBoxButtons.OK);
                txtTendvt.Focus();
                return;
            }
            string sql;
            sql = "insert into tbldonvitinh(madonvitinh, tendonvitinh) values (N'" + txtMadvt.Text + "',  N'" + txtTendvt.Text.Trim() + "')";

            DAO.chaylenh(sql);
            loaddulieu();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dgvDonvitinh.Enabled = true;
            btnLuu.Enabled = false;
            xoatextbox();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xoatextbox();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            dgvDonvitinh.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDonvitinh_Load(object sender, EventArgs e)
        {
            loaddulieu();
            btnLuu.Enabled = false;
            txtMadvt.ReadOnly = true;
        }

        private void dgvDonvitinh_Click(object sender, EventArgs e)
        {
            txtMadvt.Text = dgvDonvitinh.CurrentRow.Cells[0].Value.ToString();
            txtTendvt.Text = dgvDonvitinh.CurrentRow.Cells[1].Value.ToString();
        }        
    }
}
