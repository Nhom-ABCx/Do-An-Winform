using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using DAL;
using BEL;

namespace BAL
{
    public class BAL_SanPham
    {
        DAL_SanPham dalSP = new DAL_SanPham();
        public DataTable DocSanPham()
        { return dalSP.docSanPham(); }
        public DataTable DocSanPham(string maSP)
        { return dalSP.docSanPham(maSP); }
        public DataTable DocTenSanPham()
        {
            return dalSP.docTenSanPham();
        }
        public DataTable DocLoaiSanPham()
        {
            return dalSP.docLoaiSanPham();
        }
        public DataTable DocNhaCungCap()
        {
            return dalSP.docNhaCungCap();
        }
        public string LayMaSPMoi(string MaLoai, string MaNCC)
        {
            return dalSP.layMaSPMoi(MaLoai, MaNCC);
        }
        public int ThemSanPham(SanPham SP)
        {
            return dalSP.themSanPham(SP);
        }
        public int CapNhatSanPham(SanPham SP)
        {
            return dalSP.capNhatSanPham(SP);
        }
    }
}
