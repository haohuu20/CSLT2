using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyVLXD;


namespace QuanLyVLXD
{
    public partial class frmkhachhang : Form
    {
        DataTable tblkhachhang;
        public frmkhachhang()
        {
            InitializeComponent();
        }
        public void LoadDataToGridView()
        {
            try
            {
                DAO.openconnection();

                string sql = " select makhachhang,tenkhachhang,diachi,dienthoai from tblkhachhang";

                tblkhachhang = DAO.GetDataToTable(sql);
                dataGridViewKhachhang.DataSource = tblkhachhang;
                //không cho phép người dùng thêm mới dữ liệu trực tiếp trên lưới
                dataGridViewKhachhang.AllowUserToAddRows = false;
                //không cho phép người dùng sửa dữ liệu trực tiếp trên lưới
                dataGridViewKhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không load được dữ liệu do lỗi" + ex.ToString());
            }
        }

        private void frmkhachhang_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
            txtMakhachhang.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void dataGridViewKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhachhang.Focus();
                return;
            }
            if (tblkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMakhachhang.Text = dataGridViewKhachhang.CurrentRow.Cells[0].Value.ToString();
            txtTenkhachhang.Text = dataGridViewKhachhang.CurrentRow.Cells[1].Value.ToString();
            txtDiachi.Text = dataGridViewKhachhang.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dataGridViewKhachhang.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void resetValue()
        {
            txtMakhachhang.Text = "";
            txtTenkhachhang.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tự tạo khóa chính
            int tongds = tblkhachhang.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "KH0001";
            }
            else
            {
                int so;
                ma = "KH";
                so = Convert.ToInt32(tblkhachhang.Rows[tongds - 1][0].ToString().Substring(2,4));
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
            txtMakhachhang.Text = ma;
            txtMakhachhang.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetValue();
            LoadDataToGridView();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMakhachhang.Enabled = false;
            LoadDataToGridView();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenkhachhang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhachhang.Focus();
                return;
            }
            if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            string sql = "insert into tblkhachhang(makhachhang,tenkhachhang,diachi,dienthoai) values ('"
                                                + txtMakhachhang.Text.Trim() + "',N'"
                                                + txtTenkhachhang.Text.Trim() + "',N'"
                                                + txtDiachi.Text.Trim() + "','"
                                                + txtSDT.Text.Trim() + "')";
            DAO.chaylenh(sql);
            LoadDataToGridView();
            resetValue();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMakhachhang.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakhachhang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenkhachhang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhachhang.Focus();
                return;
            }
            if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            string sql = "update tblkhachhang set tenkhachhang=N'" + txtTenkhachhang.Text.Trim() +
                                                "',diachi=N'" + txtDiachi.Text.Trim() +
                                                "',dienthoai='" + txtSDT.Text.Trim() +
                                                "' where makhachhang='" + txtMakhachhang.Text.Trim() + "'";
            DAO.chaylenh(sql);
            LoadDataToGridView();
            resetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblkhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakhachhang.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete tblkhachhang where makhachhang='" + txtMakhachhang.Text.Trim() + "'";
                DAO.chaylenhdelete(sql);
                LoadDataToGridView();
                resetValue();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAO.closeconnection();
                this.Close();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txtMakhachhang.Enabled = true;
            
            string sql = "select makhachhang,tenkhachhang,diachi,dienthoai from tblkhachhang where 1=1";
            if (txtMakhachhang.Text.Trim() != "")
            {
                sql = sql + "and makhachhang like N'%" + txtMakhachhang.Text.Trim() + "%'";
            }
            if (txtTenkhachhang.Text.Trim() != "")
            {
                sql = sql + "and tenkhachhang like N'%" + txtTenkhachhang.Text.Trim() + "%'";
            }
            if (txtDiachi.Text.Trim() != "")
            {
                sql = sql + " and diachi like N'%" + txtDiachi.Text.Trim() + "%'";
            }
            if (txtSDT.Text.Trim() != "")
            {
                sql = sql + " and dienthoai like '%" + txtSDT.Text.Trim() + "%'";
            }

            if (sql == "select makhachhang,tenkhachhang,diachi,dienthoai from tblkhachhang where 1=1")
            {
                MessageBox.Show("Bạn phải nhập một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                tblkhachhang = DAO.GetDataToTable(sql);
                if (tblkhachhang.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có " + tblkhachhang.Rows.Count + " bản ghi thỏa mãn điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataGridViewKhachhang.DataSource = tblkhachhang;
                resetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnHuy.Enabled = true;
        }

        private void dataGridViewKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
