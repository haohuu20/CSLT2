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
using COMExcel = Microsoft.Office.Interop.Excel;



namespace QuanLyXayDung
{
    
    public partial class frmHoaDonXuat : Form
    {
        DataTable tblHoaDonXuat;
        public frmHoaDonXuat()
        {
            InitializeComponent();
        }

        private void HoaDonXuat_Load(object sender, EventArgs e)
        {

            DAO.openconnection();
          
            txttongtien.Text = "0";
            DAO.Dodulieuvaocombo("SELECT makhachhang, tenkhachhang FROM tblkhachhang", cbomakhachhang, "makhachhang", "makhachhang");
            cbomakhachhang.SelectedIndex = -1;
            DAO.Dodulieuvaocombo("SELECT makho, tenkho FROM tblkhohang", cbomakho, "makho", "tenkho");
            cbomakho.SelectedIndex = -1;

            Load_DataGridView();
            txtthue.Text = "0";
            tblHoaDonXuat = DAO.GetDataToTable("SELECT * from tblxuatkho ");
            btnhuy.Enabled = true;
            txtthanhtien.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txtmahoadonxuat.ReadOnly = true;
            txtngayxuat.ReadOnly = true;
            btnluu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
        }

        private void Load_DataGridView()
        {
            DAO.openconnection();
            string sql;          
            sql = "SELECT a.mavattu, a.tenvattu, c.tendonvitinh,b.soluong, a.giaxuat, d.thuevat, b.thanhtien FROM tblvattu AS a, tblchitietxuatkho AS b, tbldonvitinh AS c, tblxuatkho as d" +
                " WHERE b.mahoadon = N'" + txtmahoadonxuat.Text + "' AND a.mavattu=b.mavattu and a.madonvitinh = c.madonvitinh and b.mahoadon = d.mahoadon";

            SqlDataAdapter Mydata = new SqlDataAdapter(sql, DAO.con);
            tblHoaDonXuat = new DataTable();
            Mydata.Fill(tblHoaDonXuat);
            //dgchitietxuatkho.DataSource = table;
            
            dgchitietxuatkho.DataSource = tblHoaDonXuat;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgchitietxuatkho.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgchitietxuatkho.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblHoaDonXuat = DAO.GetDataToTable("SELECT * from tblxuatkho ");
        }

        private void ResetValues()
        {
            txtmahoadonxuat.Text = "";
            txtngayxuat.Text ="";
            cbomakhachhang.Text = "";
            txttongtien.Text = "0";       
            cbomavattu.Text = "";
            txtsoluong.Text = "";
            txtthanhtien.Text = "0";
            txtdiachi.Text = "";
            txtdienthoai.Text = "";
            txttenkhachhang.Text = "";
            txtthue.Text = "0";
        }

        private void LoadInfoHoaDon()
        {

            string str;
            str = "SELECT ngayxuat FROM tblxuatkho WHERE mahoadon = N'" + txtmahoadonxuat.Text + "'";
            //txtNgayban.Text = DAO.ConvertDateTime(Functions.GetFieldValues(str));
            txtngayxuat.Text =DAO.laydulieucombo(str);
            

            str = "SELECT makhachhang FROM tblxuatkho WHERE mahoadon = N'" + txtmahoadonxuat.Text + "'";
            cbomakhachhang.Text = DAO.laydulieucombo(str);

            str = "SELECT tongtien FROM tblxuatkho WHERE mahoadon = N'" + txtmahoadonxuat.Text + "'";
            txttongtien.Text = DAO.laydulieucombo(str);

            lbTongtien.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txttongtien.Text.ToString()));

            //lblBangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txtTongtien.Text);
            //lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txtTongtien.Text.ToString()));

        }

        private void ResetValuesHang()
        {
            cbomavattu.Text = "";
            txtsoluong.Text = "";
            txtdonvitinh.Text = "";
            txtthanhtien.Text = "0";
            txttenvattu.Text = "";
            txtdongia.Text = "";
            txtthue.Text = "0";
        }



        private void btndong_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            //txtngayxuat.Text = DateTime.Now.ToShortDateString();
            txtngayxuat.Text = DateTime.Now.ToShortDateString() + " "+ DateTime.Now.ToLongTimeString();
            int tongds = tblHoaDonXuat.Rows.Count;
            string ma = "";
            if (tongds <= 0)                                 //tạo mã tự động 
            {
                ma = "HDX0000001";
            }
            else
            {
                int so;
                ma = "HDX";
                so = Convert.ToInt32(tblHoaDonXuat.Rows[tongds - 1][0].ToString().Substring(3, 8));
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
            txtmahoadonxuat.Text = ma;
            cbomakhachhang.Enabled = true;
            cbomavattu.Enabled = true;

            btnluu.Enabled = true;
            btnthem.Enabled = false;
            cbomakho.Enabled = true;
            
        }

        private void btnhuy_Click(object sender, EventArgs e)               // làm lại
        {
            cbomavattu.SelectedIndex = -1;
            txtdonvitinh.Text = "";
            txttenvattu.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "";
            txtthanhtien.Text = "0";
            txtthue.Text = "0";
            txtmahoadonxuat.Text = "";
            txtngayxuat.Text = "";
            txtlydoxuat.Text = "";
            cbomakho.SelectedIndex = -1;
            cbomakhachhang.SelectedIndex = -1;
            txttenkhachhang.Text = "";
            txtdiachi.Text = "";
            txtdienthoai.Text = "";
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnHuyhoadon.Enabled = false;
            btnInhoadon.Enabled = false;
            cbomakho.Enabled = true;
            txttongtien.Text = "0";
            cbomakho.Enabled = true;
            Load_DataGridView();
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

        private void cbomavattu_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbomavattu.Text == "")
            {
                txttenvattu.Text = "";
                txtdongia.Text = "";
                txtdonvitinh.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT tenvattu FROM tblvattu WHERE mavattu =N'" + cbomavattu.SelectedValue + "'";
            txttenvattu.Text = DAO.laydulieucombo(str);
            str = "SELECT giaxuat FROM tblvattu WHERE mavattu =N'" + cbomavattu.SelectedValue + "'";
            txtdongia.Text = DAO.laydulieucombo(str);
            str = "SELECT tendonvitinh FROM tblvattu inner join tbldonvitinh on tblvattu.madonvitinh = tbldonvitinh.madonvitinh" +
                " WHERE mavattu =N'" + cbomavattu.SelectedValue + "'";
            txtdonvitinh.Text = DAO.laydulieucombo(str);
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, vat;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtthue.Text == "")
                vat = 0;
            else
                vat = Convert.ToDouble(txtthue.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg + sl * dg * vat / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtthue_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, vat;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtsoluong.Text);
            if (txtthue.Text == "")
                vat = 0;
            else
                vat = Convert.ToDouble(txtthue.Text);
            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtdongia.Text);
            tt = sl * dg + sl * dg * vat / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void txtthue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9'))  || (e.KeyChar == 46) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;

            sql = "SELECT mahoadon FROM tblxuatkho WHERE mahoadon=N'" + txtmahoadonxuat.Text + "'";
            if (!DAO.kiemtrakhoachinh(sql))
            {
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa          
                if (cbomakhachhang.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomakhachhang.Focus();
                    return;
                }
                if (cbomakho.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải chọn kho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbomakho.Focus();
                    return;
                }
                if ((txtsoluong.Text.Trim() == "") || (txtsoluong.Text.Trim() == "0"))
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtsoluong.Text = "";
                    txtsoluong.Focus();
                    return;
                }
                sql = "INSERT INTO tblxuatkho(mahoadon, ngayxuat, makhachhang, makho, lydoxuat, thuevat, Tongtien) VALUES('" + txtmahoadonxuat.Text.Trim() + "', '" +
                       (txtngayxuat.Text.Trim()) + "',N'" + cbomakhachhang.SelectedValue + "',N'" +
                        cbomakho.SelectedValue + "', N'" + txtlydoxuat.Text.Trim() + "' ," + txtthue.Text.Trim() + ","  + txttongtien.Text + ")";
                DAO.chaylenh(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cbomavattu.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            
            sql = "SELECT mavattu FROM tblchitietxuatkho WHERE mavattu=N'" + cbomavattu.SelectedValue + "' AND mahoadon = N'" + txtmahoadonxuat.Text.Trim() + "'";
            if (DAO.kiemtrakhoachinh(sql))
            {
                MessageBox.Show("Mã vật tư này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ResetValuesHang();
                cbomavattu.Focus();
                return;
            }

            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(DAO.laydulieucombo("SELECT soluong FROM tblchitietkhohang WHERE mavattu = N'" + cbomavattu.SelectedValue +
                "' and makho = '" + cbomakho.SelectedValue + "'"));
            if (Convert.ToDouble(txtsoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblchitietxuatkho(mahoadon,mavattu,soluong,thanhtien) VALUES(N'" + txtmahoadonxuat.Text.Trim() + "', N'" +
                cbomavattu.SelectedValue + "'," + txtsoluong.Text + "," + txtthanhtien.Text + ")";
            DAO.chaylenh(sql);
            Load_DataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtsoluong.Text);
            sql = "UPDATE tblchitietkhohang SET Soluong =" + SLcon + " WHERE mavattu= N'" + cbomavattu.SelectedValue + "' and makho = N'" + cbomakho.SelectedValue + "'";
            DAO.chaylenh(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToDouble(DAO.laydulieucombo("SELECT Tongtien FROM tblxuatkho WHERE mahoadon = N'" + txtmahoadonxuat.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtthanhtien.Text);
            sql = "UPDATE tblxuatkho SET Tongtien =" + Tongmoi + " WHERE mahoadon = N'" + txtmahoadonxuat.Text + "'";
            DAO.chaylenh(sql);
            txttongtien.Text = Tongmoi.ToString();
            ResetValuesHang();
            lbTongtien.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txttongtien.Text.ToString()));
            Load_DataGridView();
            //btnhuy.Enabled = false;
           // btnthem.Enabled = true;
            btnHuyhoadon.Enabled = true;
            btnInhoadon.Enabled = true;
            cbomakho.Enabled = false;
        }

        private void btnHuyhoadon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT mavattu FROM tblchitietxuatkho WHERE mahoadon = N'" + txtmahoadonxuat.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtmahoadonxuat.Text, Mahang[i], cbomakho.SelectedValue.ToString());
                //Xóa hóa đơn
                sql = "DELETE tblxuatkho WHERE mahoadon =N'" + txtmahoadonxuat.Text + "'";
                DAO.chaylenhdelete(sql);
                ResetValues();
                ResetValuesHang();
                Load_DataGridView();
                //btnHuyhoadon.Enabled = false;
                // btnInHD.Enabled = false;
                cbomakho.Enabled = true;
                lbTongtien.Text = " Bằng chữ : ";
            }
        }
        private void DelHang(string Mahoadon, string Mahang, string makho)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Soluong FROM tblchitietxuatkho WHERE mahoadon = N'" + Mahoadon + "' AND mavattu = N'" + Mahang + "'";
            s = Convert.ToDouble(DAO.laydulieucombo(sql));
            sql = "DELETE tblchitietxuatkho WHERE mahoadon = N'" + Mahoadon + "' AND mavattu = N'" + Mahang + "'";
            DAO.chaylenhdelete(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM tblchitietkhohang as a, tblkhohang as b WHERE a.makho = b.makho and a.mavattu = N'" + Mahang + "' and a.makho = N'" + makho + "'";
            sl = Convert.ToDouble(DAO.laydulieucombo(sql));
            SLcon = sl + s;
            sql = "UPDATE tblchitietkhohang SET Soluong =" + SLcon + " WHERE mavattu = N'" + Mahang + "' and makho = N'" + makho + "'";
            DAO.chaylenh(sql);
        }

        private void cbomakho_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT tblvattu.mavattu, tblvattu.tenvattu FROM tblvattu inner join tblchitietkhohang on tblvattu.mavattu = tblchitietkhohang.mavattu" +
                " where tblchitietkhohang.makho = '" + cbomakho.SelectedValue + "'";

            DAO.Dodulieuvaocombo(sql, cbomavattu, "mavattu", "mavattu");
            cbomavattu.SelectedIndex = -1;
        }

        private void dgchitietxuatkho_DoubleClick(object sender, EventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblHoaDonXuat.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = dgchitietxuatkho.CurrentRow.Cells[0].Value.ToString();
                DelHang(txtmahoadonxuat.Text, mahang, cbomakho.SelectedValue.ToString());
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(dgchitietxuatkho.CurrentRow.Cells[6].Value.ToString());
                DelUpdateTongtien(txtmahoadonxuat.Text, Thanhtien);
                Load_DataGridView();
            }
        }
        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongtien FROM tblxuatkho WHERE mahoadon = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(DAO.laydulieucombo(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblxuatkho SET tongtien =" + Tongmoi + " WHERE mahoadon = N'" + Mahoadon + "'";
            DAO.chaylenh(sql);
            txttongtien.Text = Tongmoi.ToString();
            // lblBangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(Tongmoi.ToString());
            lbTongtien.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txttongtien.Text.ToString()));
        }

        private void dgchitietxuatkho_Click(object sender, EventArgs e)
        {
            string ma = dgchitietxuatkho.CurrentRow.Cells[0].Value.ToString();
            cbomavattu.Text = DAO.laydulieucombo("select mavattu from tblvattu where mavattu = N'" + ma + "'");
            txttenvattu.Text = dgchitietxuatkho.CurrentRow.Cells[1].Value.ToString();
            txtdonvitinh.Text = dgchitietxuatkho.CurrentRow.Cells[2].Value.ToString();
            txtsoluong.Text = dgchitietxuatkho.CurrentRow.Cells[3].Value.ToString();
            txtdongia.Text = dgchitietxuatkho.CurrentRow.Cells[4].Value.ToString();
            txtthue.Text = dgchitietxuatkho.CurrentRow.Cells[5].Value.ToString();
            txtthanhtien.Text = dgchitietxuatkho.CurrentRow.Cells[6].Value.ToString();
            
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN XUẤT";
            // Biểu diễn thông tin chung của hóa đơn bán

            sql = "SELECT a.mahoadon, a.ngayxuat, a.Tongtien, d.tenkhachhang, d.Diachi, d.Dienthoai, c.Tennv FROM tblxuatkho AS a, tblkhohang AS b, tblNhanvien AS c, tblkhachhang as d" +
                " WHERE a.mahoadon = N'" +
                txtmahoadonxuat.Text.Trim() + "' AND a.makho = b.makho AND a.makhachhang = d.makhachhang and c.manv = b.manv ";
            tblThongtinHD = DAO.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();

            exRange.Range["B7:B7"].Value = "Ngày xuất:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = "'" + tblThongtinHD.Rows[0][1].ToString();

            exRange.Range["B8:B8"].Value = "Khách hàng:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B9:B9"].Value = "Địa chỉ:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B10:B10"].Value = "Điện thoại:";
            exRange.Range["C10:E10"].MergeCells = true;
            exRange.Range["C10:E10"].Value = "'" + tblThongtinHD.Rows[0][5].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.tenvattu, a.Soluong, b.giaxuat, c.thuevat, a.Thanhtien " +
                  "FROM tblchitietxuatkho AS a , tblvattu AS b, tblxuatkho as c WHERE a.mahoadon = N'" +
                  txtmahoadonxuat.Text.Trim() + "' AND a.mavattu = b.mavattu and a.mahoadon = c.mahoadon";
            tblThongtinHang = DAO.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A12:F12"].Font.Bold = true;
            exRange.Range["A12:F12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C12:F12"].ColumnWidth = 12;
            exRange.Range["A12:A12"].Value = "STT";
            exRange.Range["B12:B12"].Value = "Tên vật tư:";
            exRange.Range["C12:C12"].Value = "Số lượng";
            exRange.Range["D12:D12"].Value = "Đơn giá";
            exRange.Range["E12:E12"].Value = "Thuế VAT";
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
            //exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
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
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn ";
            exApp.Visible = true;
        }
    
        private void cbMahoadon_DropDown(object sender, EventArgs e)
        {
            DAO.FillCombo("SELECT mahoadon FROM tblchitietxuatkho", cbMahoadon,
          "mahoadon");
            cbMahoadon.SelectedIndex = -1;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            cbomakho.Enabled = false;
            cbomakhachhang.Enabled = false;
            cbomavattu.Enabled = false;
            if (cbMahoadon.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMahoadon.Focus();
                return;
            }
            txtmahoadonxuat.Text = cbMahoadon.Text;
            LoadInfoHoaDon();
            Load_DataGridView();
            btnhuy.Enabled = true;
            btnHuyhoadon.Enabled = true;
            btnInhoadon.Enabled = true;
            cbMahoadon.SelectedIndex = -1;
        }
    }
}
