using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyXayDung;
using frmDVT;
using BTL_QLBH;
using QuanLyXayDung;

namespace QuanLyVLXD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmCongviec());
            //Application.Run(new frmNhacungcap());
            //Application.Run(new frmChitietkhohang());
            Application.Run(new frmDangnhap());
            //Application.Run(new FrmDanhsachTK());
            //Application.Run(new frmMain());
            //Application.Run(new frmHoaDonXuat());
            //Application.Run(new frmTimHoaDonNhap());
            //Application.Run(new frmVatTu());
            //Application.Run(new  frmDonvitinh());
            //Application.Run(new frmHoaDonNhap());
            //Application.Run(new BaoCaoTonKho());
            //Application.Run(new BTL_QLBH.Forms.frmbaocaokho());
            //Application.Run(new BTL_QLBH.Forms.frmbaocaohdnhap());

        }
    }
}
