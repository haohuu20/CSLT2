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
using COMExcel = Microsoft.Office.Interop.Excel;
using QuanLyVLXD;


namespace QuanLyXayDung
{
    public partial class BaoCaoBanHang : Form
    {
        public BaoCaoBanHang()
        {
            InitializeComponent();
            DAO.openconnection();
        }
        DataTable tblHoadonban;
        private void BaoCaoBanHang_Load(object sender, EventArgs e)
        {
            txtdiachi.Enabled = false;
            txtdienthoai.Enabled = false;
            txttenkhachhang.Enabled = false;
            txttongtien.Enabled = false;

            //btnHienthi.Enabled = false;

            btninbaocao.Enabled = false;
            ResetValues();
            dg_HDBan.DataSource = null;

            DAO.Dodulieuvaocombo("SELECT makhachhang, tenkhachhang FROM tblkhachhang", cbomakhachhang, "makhachhang", "makhachhang");
            cbomakhachhang.SelectedIndex = -1;
            cboQuy.Items.Add("1");
            cboQuy.Items.Add("2");
            cboQuy.Items.Add("3");
            cboQuy.Items.Add("4");
        }

        private void ResetValues()
        {
            //txtdiachi.Text = "";
            //txtdienthoai.Text = "";
            //txttenkhachhang.Text = "";
            cbomakhachhang.Text = "";
            txtnambaocao.Text = "";
            cboQuy.SelectedIndex = -1;
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";

        }

        private void cbomakhachhang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomakhachhang.Text == "")
            {
                txttenkhachhang.Text = "";
                txtdiachi.Text = "";
                txtdienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select tenkhachhang from tblkhachhang where makhachhang = N'" + cbomakhachhang.SelectedValue + "'";
            txttenkhachhang.Text = DAO.laydulieucombo(str);
            str = "Select diachi from tblkhachhang where makhachhang = N'" + cbomakhachhang.SelectedValue + "'";
            txtdiachi.Text = DAO.laydulieucombo(str);
            str = "Select dienthoai from tblkhachhang where makhachhang= N'" + cbomakhachhang.SelectedValue + "'";
            txtdienthoai.Text = DAO.laydulieucombo(str);
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            ResetValues();
            dg_HDBan.DataSource = null;
        }

        private void Load_DataGridView()
        {
            dg_HDBan.Columns[0].HeaderText = "Mã hóa đơn";
            dg_HDBan.Columns[1].HeaderText = "Ngày bán";
            dg_HDBan.Columns[2].HeaderText = "Mã Khách";
            dg_HDBan.Columns[3].HeaderText = "Thành tiền";
            dg_HDBan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_HDBan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_HDBan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_HDBan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dg_HDBan.AllowUserToAddRows = false;
            dg_HDBan.EditMode = DataGridViewEditMode.EditProgrammatically;


        }
        private void btnhienthi_Click(object sender, EventArgs e)
        {
            if (cbomakhachhang.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn mã khách hàng cần tìm kiếm!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbomakhachhang.Focus();
                return;
            }
            if (txtnambaocao.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập năm cần tìm kiếm!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnambaocao.Focus();
                return;
            }
            if (cboQuy.Text.Trim() == "")
            {
                MessageBox.Show("Hãy chọn quý cần tìm kiếm!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboQuy.Focus();
                return;
            }

            string sql;
            //sql = "SELECT SoHDB,MaNV,NgayBan,MaKhach,TongTien FROM tblHoadonban WHERE tblHoadonban.MaKhach = N'" + cbomakhachhang.SelectedValue + "'";
            sql = "select mahoadon,ngayxuat,makhachhang,tongtien from tblxuatkho where tblxuatkho.makhachhang = N'" + cbomakhachhang.SelectedValue +
                "' and datepart(QQ, ngayxuat) = " + cboQuy.Text.Trim() + " AND YEAR(ngayxuat) = " + txtnambaocao.Text.Trim();
            tblHoadonban = DAO.GetDataToTable(sql);


            if (tblHoadonban.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
                return;
            }
            else
                MessageBox.Show("Có " + tblHoadonban.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dg_HDBan.DataSource = tblHoadonban;

            btninbaocao.Enabled = true;
            btnhienthi.Enabled = true;
            //cboMaKhach.SelectedIndex = -1;
            string sql1;
            sql1 = "select Sum(tongtien) from tblxuatkho where " +
                "tblxuatkho.makhachhang = N'" + cbomakhachhang.Text + "'  and datepart(QQ, tblxuatkho.ngayxuat) = " + cboQuy.Text.Trim() + " AND YEAR(ngayxuat) = " + txtnambaocao.Text.Trim();
            txttongtien.Text = DAO.laydulieucombo(sql1);
            Load_DataGridView();
        }

        private void btninbaocao_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql, sql1;
            int hang = 0, cot = 0;
            DataTable DS;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:C1"].Value = "Công Ty Vật Liệu Xây Dựng";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 6666666";


            exRange.Range["C2:G2"].Font.Size = 16;
            exRange.Range["C2:G2"].Font.Name = "Times new roman";
            exRange.Range["C2:G2"].Font.Bold = true;
            exRange.Range["C2:G2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:G2"].MergeCells = true;
            exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:G2"].Value = "Hóa đơn bán của khách "+txttenkhachhang.Text.Trim()+"";
            // Biểu diễn thông tin chung của hóa đơn bán


            
            sql = "select mahoadon,ngayxuat,tblxuatkho.makhachhang,tongtien" +
                " from tblxuatkho join tblkhachhang on tblxuatkho.makhachhang=tblkhachhang.makhachhang " +
                "where tblxuatkho.makhachhang = N'" + cbomakhachhang.Text + "'";

            sql1 = "select sum(tongtien) from tblxuatkho join tblkhachhang on tblxuatkho.makhachhang = tblkhachhang.makhachhang " +
                "where tblxuatkho.makhachhang=N'" + cbomakhachhang.Text + "' and datepart(QQ, tblxuatkho.ngayxuat) = " + cboQuy.Text.Trim() + " AND YEAR(tblxuatkho.ngayxuat) = " + txtnambaocao.Text.Trim();
            DS = DAO.GetDataToTable(sql);

            string TT = DAO.laydulieucombo(sql1);
            
            exRange.Range["B5:G5"].Font.Bold = true;
            exRange.Range["B6:F20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 12;
            exRange.Range["C5:C5"].ColumnWidth = 20;
            exRange.Range["D5:D5"].ColumnWidth = 22;
            exRange.Range["E5:E5"].ColumnWidth = 11;
            exRange.Range["F5:F5"].ColumnWidth = 11;


            exRange.Range["C4:C4"].Font.Bold = true;
            exRange.Range["C4:C4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;


            exRange.Range["B5:F5"].Font.Bold = true;
            exRange.Range["B5:F5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã hóa đơn";
            exRange.Range["D5:D5"].Value = "Ngày bán";
            exRange.Range["E5:E5"].Value = "Mã Khách";
            exRange.Range["F5:F5"].Value = "Thành tiền";
            //exRange.Range["G4:G4"].Value = "Tổng tiền";
            //exRange.Range["D4:D4"].Value = TT;


            for (hang = 0; hang < DS.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;
                for (cot = 0; cot < DS.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = DS.Rows[hang][cot].ToString();
                }
            }


            exRange = exSheet.Cells[2][hang + 8];
            exRange.Range["D1:E1"].Font.Bold = true;
            exRange.Range["D1:D1"].Value = "Tổng tiền =";
            exRange.Range["E1:E1"].Value = TT;
            exRange = exSheet.Cells[2][hang + 10];
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.ToShortDateString();
            exSheet.Name = "Báo cáo";
            exApp.Visible = true;
        }

        private void cboQuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtnambaocao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
