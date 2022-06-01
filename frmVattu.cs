using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyVLXD;
namespace QuanLyXayDung
{
    public partial class frmVatTu : Form
    {
        DataTable tblVatTu;
        public frmVatTu()
        {
            InitializeComponent();
        }

        private void frmVatTu_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btndong.Enabled = true;
            DAO.openconnection();
            string sql = " select tblvattu.mavattu, tblvattu.tenvattu, tbldonvitinh.madonvitinh, tblvattu.gianhap, tblvattu.giaxuat, tblnhacungcap.mancc " +
                "from (tblvattu inner join tblnhacungcap on tblvattu.mancc = tblnhacungcap.mancc) inner join tbldonvitinh on tblvattu.madonvitinh = tbldonvitinh.madonvitinh";
            
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, DAO.con);

            DataTable table = new DataTable();
            Mydata.Fill(table);
           dgvattu.DataSource = table;

            DAO.Dodulieuvaocombo("SELECT madonvitinh,tendonvitinh FROM tbldonvitinh", cbomadonvitinh, "madonvitinh", "tendonvitinh");
            DAO.Dodulieuvaocombo("SELECT mancc,tenncc FROM tblnhacungcap", cbomancc, "mancc", "tenncc");           
            cbomadonvitinh.SelectedIndex = -1;
            cbomancc.SelectedIndex = -1;
            Load_DataGridView();    
        }
    
        private void Load_DataGridView() // Load dữ liệu
        {
            string sql;
            sql = " select tblvattu.mavattu, tblvattu.tenvattu, tbldonvitinh.tendonvitinh, tblvattu.gianhap, tblvattu.giaxuat, tblnhacungcap.tenncc " +
                "from (tblvattu inner join tblnhacungcap on tblvattu.mancc = tblnhacungcap.mancc) inner join tbldonvitinh on tblvattu.madonvitinh = tbldonvitinh.madonvitinh";
            tblVatTu = DAO.GetDataToTable(sql);
            dgvattu.DataSource = tblVatTu;     
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgvattu.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgvattu.EditMode = DataGridViewEditMode.EditProgrammatically;
            ResetValues();
        }
        private void ResetValues()
        {
            txtmavattu.Text = "";
            txttenvattu.Text = "";
            cbomadonvitinh.Text = "";
            cbomancc.Text = "";
            txtgiaxuat.Text = "";
            txtgianhap.Text = "";   
            txtgiaxuat.Enabled = true;
            txtgianhap.Enabled = true;
        }

        private void dgvattu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmavattu.Focus();
                return;
            }
            if (tblVatTu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmavattu.Text = dgvattu.CurrentRow.Cells[0].Value.ToString();
            txttenvattu.Text = dgvattu.CurrentRow.Cells[1].Value.ToString();

            
            //cbomadonvitinh.Text = DAO.GetFieldValues("SELECT tendonvitinh FROM tbldonvitinh WHERE tendonvitinh= N'" + ma + "'");
            cbomadonvitinh.Text = dgvattu.CurrentRow.Cells[2].Value.ToString(); 
            txtgianhap.Text = dgvattu.CurrentRow.Cells[3].Value.ToString();
            txtgiaxuat.Text = dgvattu.CurrentRow.Cells[4].Value.ToString();


            //ma = dgvattu.CurrentRow.Cells[5].Value.ToString();
            

            //cbomancc.Text = DAO.GetFieldValues("SELECT tenncc FROM tblnhacungcap WHERE mancc = N'" + ma + "' ");
            cbomancc.Text = dgvattu.CurrentRow.Cells[5].Value.ToString();

            btnhuy.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            txtgiaxuat.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            ResetValues();
            int tongds = tblVatTu.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "VT0001";
            }
            else
            {
                int so;
                ma = "VT";
                so = Convert.ToInt32(tblVatTu.Rows[tongds - 1][0].ToString().Substring(2, 5));
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
            txtmavattu.Text = ma;
            txtmavattu.Enabled = false;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnsua.Enabled = false;
            dgvattu.Enabled = false;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            txtgiaxuat.Enabled = false;
            
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtmavattu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmavattu.Focus();
                return;
            }
            if (txttenvattu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenvattu.Focus();
                return;
            }
            if (cbomadonvitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomadonvitinh.Focus();
                return;
            }
            //if (cbomancc.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cbomancc.Focus();
            //    return;
            //}
            //if (txtgianhap.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtgianhap.Focus();
            //    return;
            //}
            //if (txtgiaxuat.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Bạn phải nhập giá xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtgiaxuat.Focus();
            //    return;
            //}         

            sql = "INSERT INTO tblvattu(mavattu,tenvattu,madonvitinh,gianhap,giaxuat,mancc) VALUES(N'" + txtmavattu.Text.Trim() + "',N'"
                + txttenvattu.Text.Trim() + "',N'" + cbomadonvitinh.SelectedValue.ToString() + "'," +
                txtgianhap.Text + ","+txtgiaxuat.Text +",N'" + cbomancc.SelectedValue.ToString() + "')";
            DAO.chaylenh(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnhuy.Enabled = true;
            btnluu.Enabled = false;
            txtmavattu.Enabled = false;
            dgvattu.Enabled = true;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblVatTu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmavattu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblvattu WHERE mavattu=N'" + txtmavattu.Text + "'";
                DAO.chaylenhdelete(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btndong.Enabled = true;
            dgvattu.Enabled = true;
            btnluu.Enabled = false;
            Load_DataGridView();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblVatTu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmavattu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenvattu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenvattu.Focus();
                return;
            }

            if (txtgianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgianhap.Focus();
                return;
            }

            if (txtgiaxuat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiaxuat.Focus();
                return;
            }
            if (cbomadonvitinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải mã đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomadonvitinh.Focus();
                return;
            }
            if (cbomancc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomancc.Focus();
                return;
            }
            
            sql = "UPDATE tblvattu SET  tenvattu=N'" + txttenvattu.Text.Trim().ToString() +
                "',madonvitinh=N'" + cbomadonvitinh.SelectedValue.ToString() +
                "',mancc = N'" + cbomancc.SelectedValue.ToString() +
                "',gianhap=" + txtgianhap.Text + ",giaxuat=" +
                txtgiaxuat.Text + " WHERE mavattu=N'" + txtmavattu.Text + "'";
            DAO.chaylenh(sql);
            Load_DataGridView();
            ResetValues();
            btnhuy.Enabled = false;
            txtgiaxuat.Enabled = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmavattu.Text == "") && (txttenvattu.Text == "") && (cbomadonvitinh.Text == "") && (cbomancc.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT tblvattu.mavattu, tblvattu.tenvattu, tbldonvitinh.madonvitinh, tblvattu.gianhap, tblvattu.giaxuat, tblnhacungcap.mancc FROM tblvattu JOIN tbldonvitinh ON tblvattu.madonvitinh = tbldonvitinh.madonvitinh" +
                " JOIN tblnhacungcap ON tblvattu.mancc= tblnhacungcap.mancc WHERE 1=1";
            if (txtmavattu.Text != "")
                sql = sql + " AND mavattu Like N'%" + txtmavattu.Text + "%'";
            if (txttenvattu.Text != "")
                sql = sql + " AND tenvattu Like N'%" + txttenvattu.Text + "%'";
            if (cbomadonvitinh.Text != "")
                sql = sql + " AND tblvattu.madonvitinh Like N'%" + cbomadonvitinh.SelectedValue + "%'";
            if (cbomancc.Text != "")
                sql = sql + "AND tblvattu.mancc LIKE N'%" + cbomancc.SelectedValue + "%'";
            tblVatTu = DAO.GetDataToTable(sql);
            if (tblVatTu.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblVatTu.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgvattu.DataSource = tblVatTu;
            ResetValues();
            btnhuy.Enabled = true;
            btnxoa.Enabled = true;
            btnthem.Enabled = false;
        }

        private void txtgiaxuat_TextChanged(object sender, EventArgs e)
        {
            double dgn, dgb;
            if (txtgianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(txtgianhap.Text);
            dgb = dgn * 1.1;
            txtgiaxuat.Text = dgb.ToString();
        }

        private void txtgiaxuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 46) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtgianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 46) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            double dgn, dgb;
            if (txtgianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(txtgianhap.Text);
            dgb = dgn * 1.1;
            txtgiaxuat.Text = dgb.ToString();

        }
    }
}
