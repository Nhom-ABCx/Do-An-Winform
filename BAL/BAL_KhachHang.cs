using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using DAL;
using BEL; 

namespace BAL
{
    public class BAL_KhachHang
    {
        DAL_KhachHang dalKH = new DAL_KhachHang();
        public DataTable DocKhachHang()
        {
            return dalKH.docKhachHang();
        }
        public string LayMaKHMoi()
        {
            return dalKH.layMaKHMoi();
        }
        public int ThemKhachHang(KhachHang KH)
        {
            return dalKH.themKhachHang(KH);
        }
        public int CapNhatKhachHang(KhachHang KH)
        {
            return dalKH.capNhatKhachHang(KH);
        }
    }
}
