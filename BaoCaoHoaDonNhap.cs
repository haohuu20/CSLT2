using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using QuanLyVLXD;

namespace BTL_QLBH.Forms
{
    public partial class frmbaocaohdnhap : Form
    {
        public frmbaocaohdnhap()
        {
            InitializeComponent();
        }
        DataTable tblhdn =  new DataTable();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmbaocaohdnhap_Load(object sender, EventArgs e)
        {
            DAO.openconnection();
            btnkiemtra.Enabled = true;
            btnxuat.Enabled = false;
            DAO.Dodulieuvaocombo("SELECT makho, tenkho FROM tblkhohang", cbokhohang, "makho", "tenkho");
            cbokhohang.SelectedIndex = -1;
            // Load_dghoadonnhap();
            btnxuat.Enabled = false;
            btntimlai.Enabled = false;
        }
        private void ResetValues()
        {

            cbokhohang.Text = "";

        }


        private void btnkiemtra_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select top(2) tblnhapkho.mahoadon, ngaynhap,  tenncc, tennv , tongtien  " +
                "from ((tblnhapkho join tblkhohang on tblnhapkho.makho = tblkhohang.makho ) join tblnhanvien on tblnhanvien.manv = tblnhapkho.manv) " +
                "join tblnhacungcap on tblnhacungcap.mancc = tblnhapkho.mancc WHERE tblkhohang.makho = '" + cbokhohang.SelectedValue +
                "' group by mahoadon, ngaynhap, tennv, tblnhapkho.makho, tongtien,tenncc order by tongtien desc";

            //sql= " select top(2) mahoadon, ngaynhap,  mancc, manv , makho,tenkho, tongtien from tblnhapkho  WHERE makho ='" + cbokhohang.SelectedValue  + "' group by mahoadon, ngaynhap,  mancc, manv , makho,tenkho, tongtien order by tongtien desc";
            tblhdn = DAO.GetDataToTable(sql);
            
            if (cbokhohang.Text.Trim() == "")
            {
                MessageBox.Show("Hãy Chọn Kho Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbokhohang.Focus();
                return;
            }
            if (cbokhohang.Text != "")
            {
                dgxuatbaocao.DataSource = tblhdn;
                //Load_DataGridView();
                btnxuat.Enabled = true;
                
            }
            else if (tblhdn.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            btntimlai.Enabled = true;
            btnthoat.Enabled = true;

        }
       
       
        private void btntimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgxuatbaocao.DataSource = null;
            btnxuat.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("\tVui lòng chờ...\n Đang cập nhật dữ liệu");
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblhdn1;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 15;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 30;

            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Công Ty Vật Liệu Xây Dựng";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (08)9999-9999";

            exRange.Range["F5:K5"].Font.Size = 18;
            exRange.Range["F5:K5"].Font.Name = "Times new roman";
            exRange.Range["F5:K5"].Font.Bold = true;
            exRange.Range["F5:K5"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["F5:k5"].MergeCells = true;
            exRange.Range["F5:K5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            string tenkho = DAO.laydulieucombo("select tenkho from tblkhohang where makho = '" + cbokhohang.SelectedValue + "'");
            exRange.Range["F5:F5"].Value = "Bảng báo 2 cáo hóa đơn nhập " + tenkho +" có tổng tiền lớn nhất";

            sql = " select tblchitietnhapkho.mahoadon, ngaynhap, tblchitietnhapkho.mavattu ,tenvattu ,tendonvitinh , dongianhap, soluong , thanhtien, tenncc, tennv " +
                "from (((tblchitietnhapkho  join tblvattu on tblchitietnhapkho.mavattu = tblvattu.mavattu) join tbldonvitinh on tbldonvitinh.madonvitinh = tblvattu.madonvitinh) " +
                "join tblnhapkho on tblnhapkho.mahoadon = tblchitietnhapkho.mahoadon)  join tblnhacungcap on tblnhacungcap.mancc = tblnhapkho.mancc join tblnhanvien on tblnhanvien.manv = tblnhapkho.manv " +
                "where tblchitietnhapkho.mahoadon  in ( select top(2) mahoadon from tblnhapkho where makho = '" + cbokhohang.SelectedValue +
                "'  order by tongtien desc)";
             
            tblhdn1 = DAO.GetDataToTable(sql);
            exRange.Range["C8:N8"].Font.Bold = true;//In đậm các chữ 
            exRange.Range["C8:N8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C8:C8"].ColumnWidth = 14;
            exRange.Range["D8:D8"].ColumnWidth = 17;
            exRange.Range["E8:E8"].ColumnWidth = 20;
            exRange.Range["F8:F8"].ColumnWidth = 11;
            exRange.Range["G8:G8"].ColumnWidth = 14;
            exRange.Range["H8:H8"].ColumnWidth = 15;
            exRange.Range["I8:I8"].ColumnWidth = 13;
            exRange.Range["J8:J8"].ColumnWidth = 15;
            exRange.Range["K8:K8"].ColumnWidth = 15;
            exRange.Range["L8:L8"].ColumnWidth = 35;
            exRange.Range["M8:M8"].ColumnWidth = 20;
            //Tạo dòng tiêu đề bảng
            //exRange.Range["A11:F11"].Font.Bold = true;
            //exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            //exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["C8:C8"].Value = "STT";
            exRange.Range["D8:D8"].Value = "Mã Hóa Đơn";
            exRange.Range["E8:E8"].Value = "Ngày Nhập";
            exRange.Range["F8:F8"].Value = "Mã vật tư";
            exRange.Range["G8:G8"].Value = "Tên vât tư";
            exRange.Range["H8:H8"].Value = "Đơn vị tính";
            exRange.Range["I8:I8"].Value = "Đơn giá nhập";
            exRange.Range["J8:J8"].Value = "Số lượng";
            exRange.Range["K8:K8"].Value = "Thành tiền";
            exRange.Range["L8:L8"].Value = "Tên nhà cung cấp";
            exRange.Range["M8:M8"].Value = "Tên nhân viên";
            for (hang = 0; hang < tblhdn1.Rows.Count; hang++)
            {
                exSheet.Cells[3][hang + 9] = hang + 1;//điền số thứ tự vào cột 2 bắt đầu từ hàng 6 (mở excel ra hình dung)
                for (cot = 0; cot < tblhdn1.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 4][hang + 9] = tblhdn1.Rows[hang][cot].ToString();//điền thông tin các cột còn lại từ dữ liệu đã đc đổ vào từ biến "danhsach" bắt đầu từ cột 3, hàng 6
                }
            }

           
            string tong1, tong2;
            tong1 = DAO.laydulieucombo("select tongtien from tblnhapkho where mahoadon = '" + tblhdn.Rows[0][0].ToString() + "'").ToString();
            tong2 = DAO.laydulieucombo("select tongtien from tblnhapkho where mahoadon = '" + tblhdn.Rows[1][0].ToString() + "'").ToString();
           


            //MessageBox.Show(tblhdn.Rows[0][0].ToString());
            exRange = exSheet.Cells[1][hang + 11];//chỗ này là đánh dấu vị trí viết cái dòng "Hà Nội, ngày..."
            exRange.Range["K1:L1"].MergeCells = true;
            exRange.Range["K2:L2"].MergeCells = true;
            exRange.Range["K1:L1"].Value = tblhdn.Rows[0][0].ToString() + " tổng tiền là : " + tong1;
            exRange.Range["K2:L2"].Value = tblhdn.Rows[1][0].ToString() + " tổng tiền là : " + tong2;

            exRange.Range["K5:L5"].MergeCells = true;
            exRange.Range["K5:L5"].Font.Italic = true;
            exRange.Range["K5:L5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["K5:L5"].Value = "Hà Nội, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exRange.Range["K6:L6"].MergeCells = true;
            exRange.Range["K6:L6"].Font.Italic = true;
            exRange.Range["K6:L6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["K6:L6"].Value = "Người tạo báo cáo";
            exRange.Range["K6:L6"].Font.Bold = true;
            exSheet.Name = "Báo cáo nhập hàng";
            exApp.Visible = true;
         
        }
    }
}
    
