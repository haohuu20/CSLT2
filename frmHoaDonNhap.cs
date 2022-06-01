using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace QuanLyVLXD
{
    public partial class frmHoaDonNhap : Form
    {
        DataTable tblNK;
        DataTable tblNhapkho;
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            DAO.openconnection();
            

            txttongtien.Text = "0";
            txtthanhtien.Text = "0";
            DAO.Dodulieuvaocombo("SELECT manv, tennv FROM tblnhanvien", cboManv, "manv", "manv");
            cboManv.SelectedIndex = -1;
            DAO.Dodulieuvaocombo("SELECT mavattu, tenvattu FROM tblvattu", cbomavattu, "mavattu", "mavattu");
            cbomavattu.SelectedIndex = -1;
            DAO.Dodulieuvaocombo("SELECT mancc, tenncc FROM tblnhacungcap", cbomMaNCC, "mancc", "mancc");
            cbomMaNCC.SelectedIndex = -1;
            DAO.Dodulieuvaocombo("SELECT makho, tenkho FROM tblkhohang", cboMakho, "makho", "makho");
            cboMakho.SelectedIndex = -1;
            loadDataGridView();
            btnluu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            if (txtMahoadonnhap.Text != "")           //  thao tác bên form tìm hóa đơn bán
            {
                Load_ThongtinHD();
                btnInhoadon.Enabled = true;
                loadDataGridView();
            }
        }

        private void cbomMaNCC_TextChanged(object sender, EventArgs e)
        {

            string str;
            if (cbomMaNCC.Text == "")
            {
                txtTenNCC.Text = "";
                txtdiachi.Text = "";
                txtdiachi.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select tenncc from tblnhacungcap where mancc = N'" + cbomMaNCC.SelectedValue + "'";
            txtTenNCC.Text = DAO.laydulieucombo(str);
            str = "Select diachi from tblnhacungcap where mancc = N'" + cbomMaNCC.SelectedValue + "'";
            txtdiachi.Text = DAO.laydulieucombo(str);
            str = "Select dienthoai from tblnhacungcap where mancc= N'" + cbomMaNCC.SelectedValue + "'";
            txtdienthoai.Text = DAO.laydulieucombo(str);
        }

        

        private void cboTenkho_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMakho.Text == "")
            {
                txtTenkho.Text = "";
            }

            str = "select tenkho from tblkhohang where makho = '" + cboMakho.SelectedValue + "'";
            txtTenkho.Text = DAO.laydulieucombo(str);
        }

        private void cboManv_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManv.Text == "")
            {
                txtTennv.Text = "";
            }
            str = "select tennv from tblnhanvien where manv = '" + cboManv.SelectedValue + "'";
            txtTennv.Text = DAO.laydulieucombo(str);
        }

        private void cbomavattu_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomavattu.Text == "")
            {
                txttenvattu.Text = "";
                txtdonvitinh.Text = "";
                txtdongia.Text = "0";
            }

            str = "select tenvattu from tblvattu  where mavattu = '" + cbomavattu.SelectedValue + "'";
            txttenvattu.Text = DAO.laydulieucombo(str);
            str = "select tbldonvitinh.tendonvitinh from tblvattu inner join tbldonvitinh on tblvattu.madonvitinh = tbldonvitinh.madonvitinh" +
                " where tblvattu.mavattu = '" + cbomavattu.SelectedValue + "'";
            txtdonvitinh.Text = DAO.laydulieucombo(str);
            str = "select gianhap from tblvattu where mavattu = '" + cbomavattu.SelectedValue + "'";
            txtdongia.Text = DAO.laydulieucombo(str);

        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtdongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 46) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg; 
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);          
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg;
            txtthanhtien.Text = tt.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            tblNK = new DataTable();
            tblNK = DAO.GetDataToTable("SELECT * from tblnhapkho ");
            txtNgaynhap.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            int tongds = tblNK.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "HDN0000001";
            }
            else
            {
                int so;
                ma = "HDN";
                so = Convert.ToInt32(tblNK.Rows[tongds - 1][0].ToString().Substring(3, 8));
                so = so + 1;

                if (so < 10)
                {
                    ma = ma + "000000";
                }
                else if (so < 100)
                {
                    ma = ma + "00000";
                }
                else if (so < 1000)
                {
                    ma = ma + "0000";
                }
                else if (so < 10000)
                {
                    ma = ma + "000";
                }
                else if (so < 100000)
                {
                    ma = ma + "00";
                }
                else if (so < 100000)
                {
                    ma = ma + "0";
                }
                ma = ma + so.ToString();
            }
            txtMahoadonnhap.Text = ma;
            cbomMaNCC.Enabled = true;
            cbomavattu.Enabled = true;

            btnluu.Enabled = true;
            btnthem.Enabled = false;
            cboMakho.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi, dongiamoi;
            sql = "SELECT mahoadon FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
            if (!DAO.kiemtrakhoachinh(sql))
            {
                
                if (cboManv.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManv.Focus();
                    return;
                }
                if (cbomMaNCC.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomMaNCC.Focus();
                    return;
                }
                if (cboMakho.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập mã kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMakho.Focus();
                    return;
                }
                if (cbomavattu.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập mã đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomavattu.Focus();
                    return;
                }
                if ((txtsoluong.Text.Trim() == "") || (txtsoluong.Text.Trim() == "0"))
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsoluong.Text = "";
                    txtsoluong.Focus();
                    return;
                }

                sql = "INSERT INTO tblnhapkho (mahoadon, ngaynhap, mancc, manv, makho, tongtien) VALUES (N'" + txtMahoadonnhap.Text.Trim() + "', '" + txtNgaynhap.Text.Trim() + "', '" +
                        cbomMaNCC.SelectedValue + "',N'" + cboManv.SelectedValue + "', '" + cboMakho.SelectedValue + "', "+ txttongtien.Text.Trim() + ")";
               DAO.chaylenh(sql);
                
            }

            sql = "select makho, mavattu from tblchitietkhohang where makho = '" + cboMakho.SelectedValue + "' and mavattu = '" + cbomavattu.SelectedValue + "'";
            if (!DAO.kiemtrakhoachinh(sql))
            {
                sql = "INSERT INTO tblchitietkhohang(makho, mavattu, soluong) " +
                    "VALUES('" + cboMakho.SelectedValue + "', '" + cbomavattu.SelectedValue + "', 0)";
                DAO.chaylenh(sql);
            }
                          
            if (txtdongia.Text.Trim() == "" || txtdongia.Text.Trim() == "0")
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdongia.Text = "";
                txtdongia.Focus();
                return;
            }

            if ((txtsoluong.Text.Trim() == "") || (txtsoluong.Text.Trim() == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }

            sql = "SELECT mavattu FROM tblchitietnhapkho WHERE mavattu = N'" + cbomavattu.SelectedValue + "' AND mahoadon = N'" + txtMahoadonnhap.Text.Trim() + "'";
            if (DAO.kiemtrakhoachinh(sql))
            {
                MessageBox.Show("Mã vật tư này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ResetValuesHang();
                cbomavattu.Focus();
                return;
            }
            string sq = "SELECT soluong FROM tblchitietkhohang WHERE mavattu = N'" + cbomavattu.SelectedValue + "' and makho = N'" + cboMakho.SelectedValue + "'";
            sl = Convert.ToDouble(DAO.laydulieucombo(sq));

            sql = "INSERT INTO tblchitietnhapkho(mahoadon, mavattu, soluong, dongianhap, thanhtien) VALUES(N'" + txtMahoadonnhap.Text.Trim() + "', N'" +
            cbomavattu.SelectedValue + "'," + txtsoluong.Text.Trim() + "," + txtdongia.Text.Trim() + ", " + txtthanhtien.Text + ")";
            DAO.chaylenh(sql);
            dongiamoi = Convert.ToDouble(txtdongia.Text);

            //Cập nhật lại đơn giá nhập và đơn giá bán theo giá nhập mới

            sql = "UPDATE tblvattu SET gianhap ='" + dongiamoi + "' WHERE mavattu = N'" + cbomavattu.SelectedValue + "'";
            DAO.chaylenh(sql);

            sql = "UPDATE tblvattu SET giaxuat ='" + (dongiamoi * 1.1) + "' WHERE mavattu = N'" + cbomavattu.SelectedValue + "'";
            DAO.chaylenh(sql);

            // Cập nhật lại số lượng hàng vào bảng Kho hàng
            sl = Convert.ToDouble(DAO.laydulieucombo("SELECT SoLuong FROM tblchitietkhohang WHERE mavattu = N'" + cbomavattu.SelectedValue +
                "' and makho = N'" + cboMakho.SelectedValue + "'"));
            double slmoi = Convert.ToDouble(txtsoluong.Text);
            SLcon = sl + slmoi;
            sql = "UPDATE tblchitietkhohang SET SoLuong = " + SLcon + " WHERE makho = N'" +
                cboMakho.SelectedValue + "' and mavattu = '"+cbomavattu.SelectedValue +"'";
            DAO.chaylenh(sql);

            // Cập nhật lại tổng tiền cho hóa đơn nhập

            tong = Convert.ToDouble(DAO.laydulieucombo("SELECT tongtien FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtthanhtien.Text);
            sql = "UPDATE tblnhapkho SET tongtien = " + Tongmoi + " WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
            DAO.chaylenh(sql);
            //string str = "SELECT tongtien FROM tblxuatkho WHERE sohdn = N'" + txtMahoadonnhap.Text + "'";
            //txttongtien.Text = DAO.laydulieucombo(str);

            txttongtien.Text = Tongmoi.ToString();
            lbTongtien.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txttongtien.Text.ToString()));
            loadDataGridView();
            resetvaluesVattu();
            cboMakho.Enabled = false;
            cbomMaNCC.Enabled = false;
            //btnthem.Enabled = true;
            btnHuyhoadon.Enabled = true;
            btnInhoadon.Enabled = true;
        }

        private void loadDataGridView()
        {
            tblNhapkho = new DataTable();

            DAO.openconnection();
            string sql;
            sql = "SELECT a.mavattu, a.tenvattu, c.tendonvitinh, b.soluong, b.dongianhap, b.thanhtien FROM tblvattu AS a, tblchitietnhapkho AS b, tbldonvitinh AS c" +
                " WHERE b.mahoadon = N'" + txtMahoadonnhap.Text + "' AND a.mavattu=b.mavattu and a.madonvitinh = c.madonvitinh ";

            SqlDataAdapter Mydata = new SqlDataAdapter(sql, DAO.con);
            tblNhapkho = new DataTable();
            Mydata.Fill(tblNhapkho);
            dgchitietnhapkho.DataSource = tblNhapkho;
        }
        private void resetvaluesVattu()
        {
            cbomavattu.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "0";
            txtthanhtien.Text = "0";
            txttenvattu.Text = "";
            txtdonvitinh.Text = "";
        }

        private void resetvaluesThongTinChung()
        {
            cboMakho.SelectedIndex = -1;
            cboManv.SelectedIndex = -1;
            cbomMaNCC.SelectedIndex = -1;
            txtMahoadonnhap.Text = "";
            txtNgaynhap.Text = "";
        }
        private void btnhuy_Click(object sender, EventArgs e)
        {
            resetvaluesVattu();
            resetvaluesThongTinChung();
            loadDataGridView();
            cbMahoadon.SelectedIndex = -1;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnInhoadon.Enabled = false;
            btnHuyhoadon.Enabled = false;
            lbTongtien.Text = "Bằng chữ: ";
            txttongtien.Text = "0";
        }

        private void btnHuyhoadon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string str, makho;
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT mavattu FROM tblchitietnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();

                str = "select makho from tblkhohang where makho = '" + cboMakho.SelectedValue + "'";
                makho = DAO.laydulieucombo(str);
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtMahoadonnhap.Text, Mahang[i], makho);
                //Xóa hóa đơn
                sql = "DELETE tblnhapkho WHERE mahoadon =N'" + txtMahoadonnhap.Text + "'";
                DAO.chaylenhdelete(sql);
                resetvaluesThongTinChung();
                resetvaluesVattu();
                loadDataGridView();
                btnLamlai.Enabled = false;
                btnInhoadon.Enabled = false;
                txttongtien.Text = "0";
                lbTongtien.Text = "Bằng chữ :";
            }
        }
        private void DelHang(string Mahoadon, string Mahang, string makho)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soluong FROM tblchitietnhapkho WHERE mahoadon = N'" + Mahoadon + "' AND mavattu = N'" + Mahang + "'";
            s = Convert.ToDouble(DAO.laydulieucombo(sql));
            sql = "DELETE tblchitietnhapkho WHERE mahoadon=N'" + Mahoadon + "' AND mavattu = N'" + Mahang + "'";
            DAO.chaylenhdelete(sql);

            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soluong FROM tblchitietkhohang WHERE mavattu = N'" + Mahang + "' and makho = '" + makho + "'";
            sl = Convert.ToDouble(DAO.laydulieucombo(sql));
            SLcon = sl - s;
            sql = "UPDATE tblchitietkhohang SET soluong =" + SLcon + " WHERE mavattu= N'" + Mahang + "' and makho = '" + makho + "'";
            DAO.chaylenh(sql);
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
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
            exRange.Range["A1:C1"].Value = "CÔNG TY VẬT LIỆU XÂY DỰNG";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (84) 1234567899";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP KHO";
            // Biểu diễn thông tin chung của hóa đơn bán
            ///                 0           1           2        3           4           5          6        7
            sql = "SELECT a.mahoadon, a.ngaynhap, a.tongtien, b.tenncc, b.diachi, b.dienthoai, c.tennv, d.tenkho" +
                " FROM tblnhapkho AS a, tblnhacungcap AS b, tblnhanvien AS c, tblkhohang as d " +
                "WHERE a.mahoadon = N'" + txtMahoadonnhap.Text + "' AND a.mancc = b.mancc AND a.manv =c.manv and a.makho = d.makho";
            tblThongtinHD = DAO.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:F6"].MergeCells = true;
            exRange.Range["C6:F6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:F7"].MergeCells = true;
            exRange.Range["C7:F7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:G8"].MergeCells = true;
            exRange.Range["C8:G8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:F9"].MergeCells = true;
            exRange.Range["C9:F9"].Value = "'" +tblThongtinHD.Rows[0][5].ToString();                       //  9
            exRange.Range["B10:B10"].Value = "Tên kho:";
            exRange.Range["C10:F10"].MergeCells = true;
            exRange.Range["C10:F10"].Value = tblThongtinHD.Rows[0][7].ToString();

            //Lấy thông tin các mặt hàng
            //                  0               1           2           3           4
            sql = "SELECT  a.tenvattu, c.tendonvitinh, b.soluong, b.dongianhap, b.thanhtien FROM tblvattu AS a, tblchitietnhapkho AS b, tbldonvitinh AS c" +
                " WHERE b.mahoadon = N'" + txtMahoadonnhap.Text + "' AND a.mavattu = b.mavattu and a.madonvitinh = c.madonvitinh ";

            tblThongtinHang = DAO.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A12:F12"].Font.Bold = true;
            exRange.Range["A12:F19"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C12:F12"].ColumnWidth = 12;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Tên vật tư";
            exRange.Range["C12:C12"].Value = "Đơn vị tính";
            exRange.Range["D12:D12"].Value = "Số lượng";
            exRange.Range["E12:E12"].Value = "Giá nhập";
            exRange.Range["F12:F12"].Value = "Thành tiền";

            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 13
                exSheet.Cells[1][hang + 13] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 13
                    exSheet.Cells[cot + 2][hang + 13] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 16]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[4][hang + 18]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)  == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cbMahoadon.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMahoadon.Focus();
                return;
            }
            txtMahoadonnhap.Text = cbMahoadon.Text;
            Load_ThongtinHD();
            loadDataGridView();
            btnLamlai.Enabled = true;
            btnluu.Enabled = false;
            btnInhoadon.Enabled = true;
            btnHuyhoadon.Enabled = true;
            cbMahoadon.SelectedIndex = -1;
        }

        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT ngaynhap FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
            txtNgaynhap.Text = DAO.laydulieucombo(str);

            str = "SELECT manv FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
            cboManv.Text = DAO.laydulieucombo(str);

            str = "SELECT mancc FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
            cbomMaNCC.Text = DAO.laydulieucombo(str);

            str = "SELECT makho FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
            cboMakho.Text = DAO.laydulieucombo(str);

            str = "SELECT tongtien FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
            txttongtien.Text = DAO.laydulieucombo(str);

            lbTongtien.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txttongtien.Text.ToString()));
        }

        private void cbMahoadon_DropDown(object sender, EventArgs e)
        {
            DAO.FillCombo("SELECT mahoadon FROM tblnhapkho ", cbMahoadon,
          "mahoadon");
            cbMahoadon.SelectedIndex = -1;
        }

        private void dgchitietnhapkho_DoubleClick(object sender, EventArgs e)
        {
            string mavattu, sql;
            Double thanhtienxoa, soluongxoa, sl, slcon, tong, tongmoi;
            if (tblNhapkho.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa và cập nhật lại số lượng đĩa
                mavattu = dgchitietnhapkho.CurrentRow.Cells[0].Value.ToString();
                soluongxoa = Convert.ToDouble(dgchitietnhapkho.CurrentRow.Cells[3].Value.ToString());
                thanhtienxoa = Convert.ToDouble(dgchitietnhapkho.CurrentRow.Cells[5].Value.ToString());
                sql = "DELETE tblchitietnhapkho WHERE mahoadon =N'" + txtMahoadonnhap.Text + "' AND mavattu = N'" + mavattu + "'";
                DAO.chaylenh(sql);

                // Cập nhật lại số lượng cho các loại dia
                sl = Convert.ToDouble(DAO.laydulieucombo("SELECT soluong FROM tblchitietkhohang" +
                    " WHERE mavattu = N'" + mavattu + "' and makho = '" + cboMakho.SelectedValue + "'"));
                slcon = sl - soluongxoa;
                sql = "UPDATE tblchitietkhohang SET soluong =" + slcon + " WHERE mavattu = N'" + mavattu + "' and makho = '" + cboMakho.SelectedValue + "'";
                DAO.chaylenh(sql);

                // Cập nhật lại tổng tiền cho hóa đơn nhập
                tong = Convert.ToDouble(DAO.laydulieucombo("SELECT TongTien FROM tblnhapkho WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'"));
                tongmoi = tong - thanhtienxoa;
                sql = "UPDATE tblnhapkho SET TongTien = " + tongmoi + " WHERE mahoadon = N'" + txtMahoadonnhap.Text + "'";
                DAO.chaylenh(sql);
                txttongtien.Text = tongmoi.ToString();
                lbTongtien.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txttongtien.Text.ToString()));
                loadDataGridView();
            }
        }
    }
}
