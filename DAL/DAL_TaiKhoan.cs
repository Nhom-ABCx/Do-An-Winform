using System;
using System.Data;
using System.Data.SqlClient;
using BEL;

namespace DAL
{
    public class DAL_TaiKhoan : General
    {
        public DataTable docTK(TaiKhoan tk)
        {
            return XuLy("select * from TaiKhoan,NhanVien where NhanVien.MaTK=TaiKhoan.MaTK and (eMail='" + tk._email + "' OR Phone='" + tk._phone + "') and MatKhau='" + tk._matKhau + "' and TaiKhoan.TrangThai=1");
        }
        public DataTable docDSTaiKhoan()
        {
            return XuLy("select * from TaiKhoan");
        }
        public DataTable docDSLoaiTKNV()
        {
            return XuLy("select * from LoaiTK where MaLoai!='KH'");
        }
        public DataTable docDSLoaiTKKH()
        {
            return XuLy("select * from LoaiTK where MaLoai='KH'");
        }
        public int tinhNgayLam(NhanVien nv,NgayLamViec nlv)
        {
            return ThemSuaXoa("insert NgayLamViec values('"+nlv._ngay.ToString("yyyy/MM/dd")+"','"+nv._maNV.ToString()+"','"+nlv._gioBD.ToLongTimeString()+"',null,null)");
        }
        public int ketThucNgayLam(NhanVien nv, NgayLamViec nlv)
        {
            return ThemSuaXoa("UPDATE NgayLamViec set GioKT='"+nlv._gioKT.ToLongTimeString()+"' where Ngay='"+nlv._ngay.ToString("yyyy/MM/dd") +"' and MaNV='"+nv._maNV.ToString()+"'");
        }
        public string taoMaTaiKhoanMoi(string MaLoai,string stt)
        {
            return MaLoai + stt;
        }
        public int themTaiKhoan(TaiKhoan tk)
        {   
            return ThemSuaXoa("insert TaiKhoan values('"+tk._maTK+"','"+tk._maLoai+"','"+tk._email+"','"+tk._matKhau+ "','"+tk._phone+ "','"+tk._ngayTao+ "','"+tk._trangThai+"')");
        }
    }
}
