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
    public partial class frmkhohang : Form
    {
        DataTable tblkhohang;
        public frmkhohang()
        {
            InitializeComponent();
        }
        public void LoadDataToGridView()
        {
            try
            {
                DAO.openconnection();
                string sql = " select tblkhohang.makho,tblkhohang.tenkho,tblnhanvien.manv,tblkhohang.dienthoai,tblkhohang.dientich from tblkhohang inner join tblnhanvien on tblkhohang.manv=tblnhanvien.manv";

                 tblkhohang = DAO.GetDataToTable(sql);
                dataGridViewKhohang.DataSource = tblkhohang;
                //không cho phép người dùng thêm mới dữ liệu trực tiếp trên lưới
                dataGridViewKhohang.AllowUserToAddRows = false;
                //không cho phép người dùng sửa dữ liệu trực tiếp trên lưới
                dataGridViewKhohang.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không load được dữ liệu do lỗi" + ex.ToString());
            }
        }

        private void frmkhohang_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
            txtMakho.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtSdt.Enabled = false;
            DAO.Dodulieuvaocombo("select manv, tennv from tblnhanvien", cboManv, "manv","tennv");
            cboManv.SelectedIndex = -1;
        }
        private void dataGridViewKhohang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakho.Focus();
                return;
            }
            if (tblkhohang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMakho.Text = dataGridViewKhohang.CurrentRow.Cells[0].Value.ToString();
            txtTenkho.Text = dataGridViewKhohang.CurrentRow.Cells[1].Value.ToString();

            string ma = dataGridViewKhohang.CurrentRow.Cells[2].Value.ToString();
            cboManv.Text = DAO.laydulieucombo("select tennv from tblnhanvien where manv=N'" + ma + "'");
            
            txtSdt.Text = dataGridViewKhohang.CurrentRow.Cells[3].Value.ToString();
            txtDientich.Text = dataGridViewKhohang.CurrentRow.Cells[4].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void resetValue()
        {
            txtMakho.Text = "";
            txtTenkho.Text = "";
            cboManv.Text = "";
            txtSdt.Text = "";
            txtDientich.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tự tạo khóa chính
            int tongds = tblkhohang.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "K001";
            }
            else
            {
                int so;
                ma = "K";
                so = Convert.ToInt32(tblkhohang.Rows[tongds - 1][0].ToString().Substring(1, 4));
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
            resetValue();
            txtMakho.Text = ma;
            txtMakho.Enabled = false;
            txtSdt.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetValue();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMakho.Enabled = false;
            LoadDataToGridView();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenkho.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkho.Focus();
                return;
            }
            if (cboManv.Text.Trim() == "")
            {
                MessageBox.Show(" Bạn chưa nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboManv.Focus();
                return;
            }
            if (txtSdt.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
                return;
            }
            if (txtDientich.Text.Trim() == "")
            {
                MessageBox.Show(" Bạn chưa nhập diện tích kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDientich.Focus();
                return;
            }
            //insert into tblkhohang(makho, tenkho, manv, dienthoai, dientich) values('K003','Kho 3','NV0011','0935781264',1000)
            string sql = "insert into tblkhohang(makho,tenkho,manv,dienthoai,dientich) values ('"
                                                + txtMakho.Text.Trim() + "',N'"
                                                + txtTenkho.Text.Trim() + "',N'"
                                                + cboManv.SelectedValue.ToString() + "','"
                                                + txtSdt.Text.Trim() + "',"
                                                + txtDientich.Text.Trim() + ")";
            DAO.chaylenh(sql);
            LoadDataToGridView();
            resetValue();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMakho.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblkhohang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakho.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenkho.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkho.Focus();
                return;
            }
            if (cboManv.Text.Trim() == "")
            {
                MessageBox.Show(" Bạn chưa nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboManv.Focus();
                return;
            }
            if (txtSdt.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
                return;
            }
            if (txtDientich.Text.Trim() == "")
            {
                MessageBox.Show(" Bạn chưa nhập diện tích kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDientich.Focus();
                return;
            }
            //update tblkhohang set tenkho='Kho 5',manv='NV0010',dienthoai='0365214',dientich=2000 where makho='H004'
            string sql = "update tblkhohang set tenkho= N'" + txtTenkho.Text.Trim() + "',manv='"
                                                         + cboManv.SelectedValue.ToString()+ "',dienthoai='"
                                                         + txtSdt.Text.Trim() + "',dientich="
                                                         + txtDientich.Text.Trim() + "where makho='"
                                                         + txtMakho.Text.Trim() + "'";
            DAO.chaylenh(sql);
            LoadDataToGridView();
            resetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblkhohang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakho.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete tblkhohang where makho='" + txtMakho.Text.Trim() + "'";
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
            txtMakho.Enabled = true;
            
            //select tblkhohang.makho,tblkhohang.tenkho,tblnhanvien.manv,tblkhohang.dienthoai,tblkhohang.dientich from tblkhohang inner join tblnhanvien on tblkhohang.manv=tblnhanvien.manv where 1=1 and makho like N'%K001%'
            string sql = "select tblkhohang.makho,tblkhohang.tenkho,tblnhanvien.manv,tblkhohang.dienthoai,tblkhohang.dientich from tblkhohang inner join tblnhanvien on tblkhohang.manv=tblnhanvien.manv where 1=1";
            if (txtMakho.Text.Trim() != "")
            {
                sql = sql + "and makho like N'%" + txtMakho.Text.Trim() + "%'";
            }
            if (txtTenkho.Text.Trim() != "")
            {
                sql = sql + "and tenkho like N'%" + txtTenkho.Text.Trim() + "%'";
            }
            if (cboManv.Text != "")
            {
                sql = sql + "and tblnhanvien.manv like N'%" + cboManv.SelectedValue + "%'";
            }
            if (txtSdt.Text.Trim() != "")
            {
                sql = sql + " and tblkhohang.dienthoai like '%" + txtSdt.Text.Trim() + "%'";
            }
            if (txtDientich.Text.Trim() != "")
            {
                sql = sql + " and dientich = " + txtDientich.Text.Trim() ;
            }

            if (sql == "select tblkhohang.makho,tblkhohang.tenkho,tblnhanvien.manv,tblkhohang.dienthoai,tblkhohang.dientich from tblkhohang inner join tblnhanvien on tblkhohang.manv=tblnhanvien.manv where 1=1")
            {
                MessageBox.Show("Bạn phải nhập một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                tblkhohang = DAO.GetDataToTable(sql);
                if (tblkhohang.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có " + tblkhohang.Rows.Count + " bản ghi thỏa mãn điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataGridViewKhohang.DataSource = tblkhohang;
                resetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnHuy.Enabled = true;
        }

        private void txtDientich_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cboManv_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManv.Text == "")
            {
               txtSdt.Text = "";
            }

            str = "select dienthoai from tblnhanvien  where manv = '" + cboManv.SelectedValue + "'";
            txtSdt.Text = DAO.laydulieucombo(str);
           
        }
    }
}
