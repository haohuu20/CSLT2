using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QuanLyVLXD
{
    public partial class frmChitietkhohang : Form
    {
        DataTable tblCTkho;
        public frmChitietkhohang()
        {
            InitializeComponent();
        }
       
        private void loaddulieu()                        // Load form
        {
            try
            {
                DAO.openconnection();
                string sql = "select tblkhohang.makho, tblkhohang.tenkho, tblvattu.tenvattu, tblchitietkhohang.soluong from " +
                "(tblkhohang inner join  tblchitietkhohang on tblkhohang.makho = tblchitietkhohang.makho)" +
                "inner join tblvattu on tblchitietkhohang.mavattu = tblvattu.mavattu where 1=1 ";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                tblCTkho = new DataTable();
                mydata.Fill(tblCTkho);
                dgvChitietkhohang.DataSource = tblCTkho;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmChitietkhohang_Load(object sender, EventArgs e)
        {
            DAO.openconnection();
            DAO.Dodulieuvaocombo("select makho, tenkho from tblkhohang", cbMakho, "tenkho", "makho");
            DAO.Dodulieuvaocombo("select mavattu, tenvattu from tblvattu", cbMavattu, "tenvattu", "mavattu");
            cbMakho.SelectedIndex = -1;
            cbMavattu.SelectedIndex = -1;
            loaddulieu();
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql = "select tblkhohang.makho, tblkhohang.tenkho, tblvattu.tenvattu, tblchitietkhohang.soluong from " +
                "(tblkhohang inner join  tblchitietkhohang on tblkhohang.makho = tblchitietkhohang.makho)" +
                " inner join tblvattu on tblchitietkhohang.mavattu = tblvattu.mavattu where 1=1 ";
            if (txtTenkho.Text.Trim() != "")
            {
                sql = sql + " and tblkhohang.tenkho like N'%" + txtTenkho.Text.Trim() + "%'";
            }
            if (txtTenvattu.Text.Trim() != "")
            {
                sql = sql + " and tblvattu.tenvattu like N'%" + txtTenvattu.Text.Trim() + "%'";
            }
            if (cbMakho.SelectedIndex > -1)
            {
                sql = sql + " and tblkhohang.tenkho = N'" + cbMakho.SelectedValue + "'";
            }
            if (cbMavattu.SelectedIndex > -1)
            {
                sql = sql + " and tblvattu.tenvattu = N'" + cbMavattu.SelectedValue + "'";
            }

            if (sql == "select tblkhohang.makho, tblkhohang.tenkho, tblvattu.tenvattu, tblchitietkhohang.soluong from " +
                "(tblkhohang inner join  tblchitietkhohang on tblkhohang.makho = tblchitietkhohang.makho)" +
                " inner join tblvattu on tblchitietkhohang.mavattu = tblvattu.mavattu where 1=1 ")
            {
                MessageBox.Show("Bạn phải có ít nhất một điều kiện mới có thể tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    lbthongtin.Text = "Có " + tbl.Rows.Count + " bản ghi thỏa mã điều kiện!";
                }
                dgvChitietkhohang.DataSource = tbl;
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMakho_SelectedIndexChanged(object sender, EventArgs e)
        {          
            txtTenkho.Text = DAO.laydulieucombo("select tenkho from tblkhohang where tenkho = N'" + cbMakho.SelectedValue + "'");
        }

        private void cbMavattu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenvattu.Text = DAO.laydulieucombo("select tenvattu from tblvattu where tenvattu = N'" + cbMavattu.SelectedValue + "'");
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
            lbthongtin.Text = "";
            loaddulieu();
            cbMakho.SelectedIndex = -1;
            cbMavattu.SelectedIndex = -1;
            txtTenkho.Text = "";
            txtTenvattu.Text = "";
        }
    }
}
