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

namespace QuanLyVLXD
{
    public partial class frmnhanvien : Form
    {
        DataTable tblnhanvien;
        public frmnhanvien()
        {
            InitializeComponent();
        }
        public void LoadDataToGridView()
        {
            try
            {
                DAO.openconnection();

                string sql = " select tblnhanvien.manv,tblnhanvien.tennv,tblnhanvien.gioitinh,tblnhanvien.ngaysinh," +
                    "tblnhanvien.dienthoai,tblcongviec.tencongviec from tblnhanvien inner join tblcongviec on tblnhanvien.macv=tblcongviec.macv";

                tblnhanvien = DAO.GetDataToTable(sql);
                dataGridViewNhanvien.DataSource = tblnhanvien;
                //không cho phép người dùng thêm mới dữ liệu trực tiếp trên lưới
                dataGridViewNhanvien.AllowUserToAddRows = false;
                //không cho phép người dùng sửa dữ liệu trực tiếp trên lưới
                dataGridViewNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không load được dữ liệu do lỗi"+ ex.ToString());
            }
        }

        private void frmnhanvien_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
            txtManv.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            DAO.Dodulieuvaocombo("select macv, tencongviec from tblcongviec", cboMacv, "macv", "tencongviec");
            //DAO.FillCombo("select macv from tblcongviec", cboMacv, "macv");
            cboMacv.SelectedIndex = -1;

        }

        private void dataGridViewNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return;
            }
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtManv.Text = dataGridViewNhanvien.CurrentRow.Cells[0].Value.ToString();
            txtTennv.Text = dataGridViewNhanvien.CurrentRow.Cells[1].Value.ToString();
            if (dataGridViewNhanvien.CurrentRow.Cells[2].Value.ToString() == "Nam")
            {
                chkGioitinh.Checked = true;
            }
            else
            {
                chkGioitinh.Checked = false;
            }    
            mskNgaysinh.Text = dataGridViewNhanvien.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = dataGridViewNhanvien.CurrentRow.Cells[4].Value.ToString();

            string ten = dataGridViewNhanvien.CurrentRow.Cells[5].Value.ToString();
            cboMacv.Text = DAO.laydulieucombo("select tencongviec from tblcongviec where tencongviec=N'" + ten + "'");


            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void resetValue()
        {
            txtManv.Text = "";
            txtTennv.Text = "";
            chkGioitinh.Checked =false;
            mskNgaysinh.Text = "";
            txtSDT.Text = "";
            cboMacv.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetValue();
            //Tự tạo khóa chính
            int tongds = tblnhanvien.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "NV001";
            }
            else
            {
                int so;
                ma = "NV";
                so = Convert.ToInt32(tblnhanvien.Rows[tongds - 1][0].ToString().Substring(2, 5));
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
            txtManv.Text = ma;
            txtManv.Enabled = false;
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
            txtManv.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTennv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennv.Focus();
                return;
            }
            string gt;
            if (chkGioitinh.Checked == true)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            if (mskNgaysinh.Text.Trim() == "/  /")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNgaysinh.Focus();
                return;
            }
            if (!DAO.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if(txtSDT.Text.Trim()=="")
            {
                MessageBox.Show("Bạn chưa số điện thoại nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            if (cboMacv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã công việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMacv.Focus();
                return;
            }
            string sql = "insert into tblnhanvien(manv,tennv,gioitinh,ngaysinh,dienthoai,macv) values ('"
                                                + txtManv.Text.Trim() + "','"
                                                + txtTennv.Text.Trim() + "',N'"
                                                + gt+"','"
                                                + (mskNgaysinh.Text) + "','"
                                                + txtSDT.Text.Trim() + "','"
                                                + cboMacv.SelectedValue.ToString() + "')";
            DAO.chaylenh(sql);
            LoadDataToGridView();
            resetValue();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtManv.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennv.Focus();
                return;
            }
            string gt;
            if (chkGioitinh.Checked == true)
            {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            if (mskNgaysinh.Text.Trim() == "/  /")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNgaysinh.Focus();
                return;
            }
            if (!DAO.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa số điện thoại nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            if (cboMacv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã công việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMacv.Focus();
                return;
            }
            string sql = "UPDATE tblnhanvien SET  tennv=N'" + txtTennv.Text.Trim() + "',gioitinh=N'"
                                    + gt + "',ngaysinh='"
                                    + mskNgaysinh.Text + "',dienthoai='"
                                    + txtSDT.Text.Trim() + "',macv='"
                                    + cboMacv.SelectedValue.ToString() + "' where manv='"
                                    + txtManv.Text.Trim() + "'";
            DAO.chaylenh(sql);
            LoadDataToGridView();
            resetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete tblnhanvien where manv='" + txtManv.Text.Trim() + "'";
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
            txtManv.Enabled = true;           
            
            string sql = " select tblnhanvien.manv,tblnhanvien.tennv,tblnhanvien.gioitinh,tblnhanvien.ngaysinh," +
                    "tblnhanvien.dienthoai,tblcongviec.tencongviec from tblnhanvien inner join tblcongviec on tblnhanvien.macv = tblcongviec.macv where 1=1 ";
            if (txtManv.Text.Trim() != "")
            {
                sql = sql + "and manv like N'%" + txtManv.Text.Trim() + "%'";
            }
            if (txtTennv.Text.Trim() != "")
            {
                sql = sql + "and tennv like N'%" + txtTennv.Text.Trim() + "%'";
            }
            if (cboMacv.Text != "")
            {
                sql = sql + "and tblcongviec.macv like N'%" + cboMacv.SelectedValue + "%'";
            }           
            if (txtSDT.Text.Trim() != "")
            {
                sql = sql + " and dienthoai like '%" + txtSDT.Text.Trim() + "%'";
            }
            string gt;
            if (chkGioitinh.Checked == true)
            {
                gt = "Nam";               
            }
            else
            {
                gt = "Nữ";
            }
            sql = sql + " and gioitinh = N'" + gt + "'";
            if(mskNgaysinh.Text.Trim() != "/  /")
            {
                sql = sql + " and ngaysinh = '" + mskNgaysinh.Text.Trim() + "'";
            }

            if (sql == " select tblnhanvien.manv,tblnhanvien.tennv,tblnhanvien.gioitinh,tblnhanvien.ngaysinh," +
                    "tblnhanvien.dienthoai,tblcongviec.tencongviec from tblnhanvien inner join tblcongviec on tblnhanvien.macv = tblcongviec.macv where 1=1 ")
            {
                MessageBox.Show("Bạn phải nhập một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                tblnhanvien = DAO.GetDataToTable(sql);
                if (tblnhanvien.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có " + tblnhanvien.Rows.Count + " bản ghi thỏa mãn điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataGridViewNhanvien.DataSource = tblnhanvien;
                resetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnHuy.Enabled = true;
            btnThem.Enabled = true;
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
