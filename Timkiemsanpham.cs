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
    public partial class frmtimkiemsanpham : Form
    {
    
        public frmtimkiemsanpham()
        {
            InitializeComponent();
        }
        DataTable tbltimkiemsanpham;
        public void LoadDataToGridView()
        {
           
            //không cho phép người dùng thêm mới dữ liệu trực tiếp trên lưới
            dataGridViewTKSP.AllowUserToAddRows = false;
            //không cho phép người dùng sửa dữ liệu trực tiếp trên lưới
            dataGridViewTKSP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void frmtimkiemsanpham_Load(object sender, EventArgs e)
        {
            resetValue();
            dataGridViewTKSP.DataSource = null;
        }
        private void resetValue()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtTenvattu.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            DAO.openconnection();
            if ((txtMavattu.Text == "") && (txtTenvattu.Text == "") && (txtMakho.Text == "")
                && (txtTenkho.Text == "") && (txtSoluong.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "select tblvattu.mavattu,tblvattu.tenvattu,tblkhohang.makho,tblkhohang.tenkho," +
                "tblchitietkhohang.soluong,tblvattu.gianhap,tblvattu.giaxuat" +
                " from tblvattu join tblchitietkhohang on tblvattu.mavattu=tblchitietkhohang.mavattu" +
                " join tblkhohang on tblkhohang.makho=tblchitietkhohang.makho where 1=1";
            if (txtMavattu.Text != "")
            {
                sql = sql + " and tblvattu.mavattu like N'%" + txtMavattu.Text + "%'";
            }
            if (txtTenvattu.Text != "")
            {
                sql = sql + " and tblvattu.tenvattu like N'%" + txtTenvattu.Text + "%'";
            }
            if (txtMakho.Text != "")
            {
                sql = sql + " and tblkhohang.makho like N'%" + txtMakho.Text + "%'";
            }
            if (txtTenkho.Text != "")
            {
                sql = sql + " and tblkhohang.tenkho like N'%" + txtTenkho.Text + "%'";
            }
            if (txtSoluong.Text != "")
            {
                //sql = sql + " and tblchitietkhohang.soluong <= " + txtSoluong.Text;
                sql = sql + " and tblchitietkhohang.soluong = " + txtSoluong.Text;
            }
            try
            {
                tbltimkiemsanpham = DAO.GetDataToTable(sql);
                if (tbltimkiemsanpham.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có " + tbltimkiemsanpham.Rows.Count + " bản ghi thỏa mãn điều kiện ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataGridViewTKSP.DataSource = tbltimkiemsanpham;
                LoadDataToGridView();
                resetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            resetValue();
            dataGridViewTKSP.DataSource = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}