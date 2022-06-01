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
    public partial class BaoCaoTonKho : Form
    {
        public BaoCaoTonKho()
        {
            InitializeComponent();
            DAO.openconnection();
        }
        DataTable tblBCHangton;

        private void BaoCaoTonKho_Load(object sender, EventArgs e)
        {
            cboquybaocao.Enabled = false;
            txtnambaocao.Enabled = false;
            btntaobaocao.Enabled = true;
            btndong.Enabled = true;
            btninbaocao.Enabled = false;
            btnhienthi.Enabled = false;
            //Đổ 4 quí vào ComboBox
            cboquybaocao.Items.Add("1");
            cboquybaocao.Items.Add("2");
            cboquybaocao.Items.Add("3");
            cboquybaocao.Items.Add("4");
        }

        private void btntaobaocao_Click(object sender, EventArgs e)
        {
            cboquybaocao.Enabled = true;
            txtnambaocao.Enabled = true;
            btnhienthi.Enabled = true;
            txtnambaocao.Text = "";
            cboquybaocao.Text = "";
            cboquybaocao.Focus();
            dg_Tonkho.DataSource = null;
        }

        private void btninbaocao_Click(object sender, EventArgs e)
        {
            if (txtnambaocao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnambaocao.Focus();
                return;
            }
            if (cboquybaocao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn quý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboquybaocao.Focus();
                return;
            }

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable danhsach;


            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Size = 11;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;//đặt màu cho chữ
            exRange.Range["A1:A1"].ColumnWidth = 10;//độ rộng cột
            exRange.Range["B1:B1"].ColumnWidth = 16;
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:C1"].Value = "Công Ty Vật Liệu Xây Dựng";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 66666666";
            exRange.Range["C2:G2"].Font.Size = 16;
            exRange.Range["C2:G2"].Font.Bold = true;
            exRange.Range["C2:G2"].Font.ColorIndex = 3;
            exRange.Range["C2:G2"].MergeCells = true;
            exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:G2"].Value = "Báo cáo hàng không bán được theo quý ";
            exRange.Range["D3:F3"].Font.Size = 14;
            exRange.Range["D3:F3"].Font.Bold = true;
            exRange.Range["D3:F3"].Font.ColorIndex = 3;
            exRange.Range["D3:F3"].MergeCells = true;
            exRange.Range["D3:F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D3:F3"].Value = "Quý " + cboquybaocao.SelectedItem + " Năm " + txtnambaocao.Text; //In ra quí + năm báo cáo
                                                                                                             //sql = "select a.MaDia, a.TenDia, a.SoLuong from tblKhodia as a where a.MaDia not in (select tblKhodia.MaDia from tblKhodia join tblChitietHDB on tblKhodia.MaDia=tblChitietHDB.MaDia join tblHoadonban on tblChitietHDB.SoHDB=tblHoadonban.SoHDB where (datepart(QQ,NgayBan) = '" + cboQui.Text + "') AND (YEAR(NgayBan) = '" + txtNam.Text + "'))";

            sql =  "select tblvattu.mavattu, tenvattu, tendonvitinh,soluong,gianhap,giaxuat,tenkho " +
                "from(((tblvattu inner join tbldonvitinh on tblvattu.madonvitinh = tbldonvitinh.madonvitinh) inner join tblchitietkhohang on tblchitietkhohang.mavattu = tblvattu.mavattu) inner join tblkhohang on tblchitietkhohang.makho = tblkhohang.makho) " +
                "where tblvattu.mavattu not in (select tblchitietxuatkho.mavattu " +
                "from tblchitietxuatkho join tblxuatkho on tblchitietxuatkho.mahoadon=tblxuatkho.mahoadon where " +
                "(datepart(QQ, ngayxuat) = '" + cboquybaocao.Text.Trim() + "') AND(YEAR(ngayxuat) = '" + txtnambaocao.Text.Trim() + "') ) ";

            danhsach = DAO.GetDataToTable(sql);//đổ dữ liệu từ lệnh sql vào biến "danhsach"

            exRange.Range["B5:F5"].Font.Bold = true;//In đậm các chữ 
            exRange.Range["B5:I48"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 14;
            exRange.Range["C5:C5"].ColumnWidth = 13;
            exRange.Range["D5:D5"].ColumnWidth = 20;
            exRange.Range["E5:E5"].ColumnWidth = 20;
            exRange.Range["F5:F5"].ColumnWidth = 13;
            exRange.Range["G5:G5"].ColumnWidth = 13;
            exRange.Range["H5:H5"].ColumnWidth = 13;
            exRange.Range["I5:I5"].ColumnWidth = 13;




            exRange.Range["B5:I5"].Font.Bold = true;
            exRange.Range["B5:I5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã vật tư";
            exRange.Range["D5:D5"].Value = "Tên vật tư";
            exRange.Range["E5:E5"].Value = "Đơn vị tính";
            exRange.Range["F5:F5"].Value = "Số lượng";
            exRange.Range["G5:G5"].Value = "Giá nhập";
            exRange.Range["H5:H5"].Value = "Giá xuất";
            exRange.Range["I5:I5"].Value = "Tên kho";
            //exRange.Range["F5:F5"].Value = "Quí " + cboQui.SelectedItem;


            //vòng lặp để đổ dữ liệu từ biến "danhsach" vào excel
            for (hang = 0; hang < danhsach.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;//điền số thứ tự vào cột 2 bắt đầu từ hàng 6 (mở excel ra hình dung)
                for (cot = 0; cot < danhsach.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = danhsach.Rows[hang][cot].ToString();//điền thông tin các cột còn lại từ dữ liệu đã đc đổ vào từ biến "danhsach" bắt đầu từ cột 3, hàng 6
                }
            }
            //
            exRange = exSheet.Cells[1][hang + 8];//chỗ này là đánh dấu vị trí viết cái dòng "Hà Nội, ngày..."
            exRange.Range["E1:H1"].MergeCells = true;
            exRange.Range["E1:H1"].Font.Italic = true;
            exRange.Range["E1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E1:H1"].Value = "Hà Nội, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Name = "Báo cáo";
            exApp.Visible = true;
            //exRange = exSheet.Cells[2][hang + 8];//chỗ này là đánh dấu vị trí viết cái dòng "Hà Nội, ngày..."
            //exRange.Range["D1:F1"].MergeCells = true;
            //exRange.Range["D1:F1"].Font.Italic = true;
            //exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            //exSheet.Name = "Báo cáo";
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            if (cboquybaocao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn quý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboquybaocao.Focus();
                return;
            }
            if (txtnambaocao.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnambaocao.Focus();
                return;
            }

            string sql = "select tblvattu.mavattu, tenvattu, tendonvitinh,soluong,gianhap,giaxuat,tenkho " +
                "from(((tblvattu inner join tbldonvitinh on tblvattu.madonvitinh = tbldonvitinh.madonvitinh) inner join tblchitietkhohang on tblchitietkhohang.mavattu = tblvattu.mavattu) inner join tblkhohang on tblchitietkhohang.makho = tblkhohang.makho) " +
                "where tblvattu.mavattu not in (select tblchitietxuatkho.mavattu " +
                "from tblchitietxuatkho join tblxuatkho on tblchitietxuatkho.mahoadon=tblxuatkho.mahoadon where " +
                "(datepart(QQ, ngayxuat) = '"+ cboquybaocao.Text.Trim() +"') AND (YEAR(ngayxuat) = '" + txtnambaocao.Text.Trim() + "') ) ";


        

            tblBCHangton = DAO.GetDataToTable(sql);
            dg_Tonkho.DataSource = tblBCHangton;
            dg_Tonkho.Columns[0].HeaderText = "Mã vật tư";
            dg_Tonkho.Columns[1].HeaderText = "Tên vật tư";
            dg_Tonkho.Columns[2].HeaderText = "Đơn vị tính";
            dg_Tonkho.Columns[3].HeaderText = "Số lượng";
            dg_Tonkho.Columns[4].HeaderText = "Giá nhập";
            dg_Tonkho.Columns[5].HeaderText = "Giá xuất";
            dg_Tonkho.Columns[6].HeaderText = "Tên kho";
            //Chiều rộng cột phù hợp với nội dung tất cả các ô kể cả tiêu đề

            dg_Tonkho.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dg_Tonkho.AllowUserToAddRows = false;
            dg_Tonkho.EditMode = DataGridViewEditMode.EditProgrammatically;
            cboquybaocao.Enabled = false;
            txtnambaocao.Enabled = false;
            btntaobaocao.Enabled = true;
            btninbaocao.Enabled = true;
            btnhienthi.Enabled = false;
        }

        private void cboquybaocao_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btndong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
