using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BEL;

namespace DAL
{
    public class DAL_HoaDon : General
    {
        public DataTable docHoaDon()
        {
            return XuLy("select * from HoaDon");
        }
        public DataTable docHoaDonTrangThai0()
        {
            return XuLy("select * from HoaDon where TrangThai=0");
        }
        public DataTable docHoaDonTrangThai1()
        {
            return XuLy("select * from HoaDon where TrangThai=1");
        }
        public DataTable docTTHoaDon(string mahd)
        {
            return XuLy("select MaHD,NgayLapHD,HoaDon.MaNV,NhanVien.HoTenNV,hoadon.MaKh,KhachHang.HoTenKh,DChiGiao,HoaDon.TrangThai from HoaDon,NhanVien,KhachHang where HoaDon.MaNV=NhanVien.MaNV and HoaDon.MaKh=KhachHang.MaKh and MaHD='"+mahd+"'");
        }
        public DataTable docTTct_HoaDon(string mahd)
        {
            return XuLy("select HoaDon.MaHD,CT_HoaDon.MaSp,TenSp,CT_HoaDon.SoLuong,GiaBan,GiaGiam,ChietKhau,ThanhTien,TongTien,HoaDon.TrangThai from HoaDon,CT_HoaDon,SanPham where SanPham.MaSp=CT_HoaDon.MaSp and HoaDon.MaHD=CT_HoaDon.MaHD and HoaDon.MaHD='" + mahd+"'");
        }
        public bool TrangThaiHD(string mahd)
        {
            bool kq = false;
            string sql = "Select TrangThai from HoaDon where MaHD='"+mahd+"'";
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);

                kq = bool.Parse(cmd.ExecuteScalar().ToString()); //tra ve 1 ket qua duy nhat'cua cot dau` tien cua? hang dau`
            }
            catch (Exception)
            { }
            finally { con.Close(); }
            return kq;
        }
        public int themCT_HoaDon(string mahd, string masp, int soluong, int giagiam, int chietkhau)
        {
            return ThemSuaXoa("insert CT_HoaDon values('" + mahd + "','" + masp + "'," + soluong + "," + giagiam + "," + chietkhau + ",0" + ")" +
                "UPDATE SanPham set SoLuong-=" + soluong + "where MaSp='" + masp + "'");
        }
        public int capNhatCT_HoaDon(string mahd, string masp, int soluong,int soLuongUpdateSP, int giagiam, int chietkhau)
        {
            return ThemSuaXoa("update CT_HoaDon set SoLuong=" + soluong + ",GiaGiam=" + giagiam + ",ChietKhau=" + chietkhau + " where MaHD='" + mahd + "'and MaSp='" + masp + "'" +
                "UPDATE SanPham set SoLuong-=" + soLuongUpdateSP + "where MaSp='" + masp + "'");
        }
        public int xoaCT_HoaDon(string mahd, string masp,int soLuongUpdateSP)
        {
            return ThemSuaXoa("delete from CT_HoaDon where MaSp='" + masp + "' and MaHD='" + mahd + "'" +
                "UPDATE SanPham set SoLuong+=" + soLuongUpdateSP + "where MaSp='" + masp + "'");
        }
        public int themHoaDon(HoaDon hd)
        {
            return ThemSuaXoa("insert into HoaDon values('" + hd._maHD + "','" + hd._ngayLapHD + "','" + hd._maNV + "','" + hd._maKH + "','" + hd._diaChiGiao + "','" + hd._tongTien + "','" + hd._trangThai + "')");
        }
        public int capNhatHoaDon(HoaDon hd)
        {
            return ThemSuaXoa("UPDATE HoaDon set MaKh='"+hd._maKH+"',DChiGiao='"+hd._diaChiGiao+"' where MaHD='"+hd._maHD+"'");
        }
        public int xoaHoaDon(string mahd)
        {
            return ThemSuaXoa("delete from CT_HoaDon where MaHD='"+ mahd + "'" +
                "delete from HoaDon where MaHD='"+ mahd + "'");
        }
        public int thanhToanHD(string maHD)
        {
            return ThemSuaXoa("UPDATE HoaDon set TrangThai=1 where MaHD='"+maHD+"'");
        }
    }
}
