using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using DAL;
using BEL;

namespace BAL
{
    public class BAL_NhanVien
    {
        DAL_NhanVien dalNV = new DAL_NhanVien();
        public DataTable DocNhanVien()
        {
            return dalNV.docNhanVien();
        }
        public DataTable DocNhanVienTrangThai0()
        {
            return dalNV.docNhanVienTrangThai0();
        }
        public DataTable DocNhanVienTrangThai1()
        {
            return dalNV.docNhanVienTrangThai1();
        }
        public string LayMaNVMoi()
        {
            return dalNV.layMaNVMoi();
        }
        public int ThemNhanVien(NhanVien NV)
        {
            return dalNV.themNhanVien(NV);
        }
        public int CapNhatNhanVien(NhanVien nv)
        {
            return dalNV.capNhatNhanVien(nv);
        }
    }
}
