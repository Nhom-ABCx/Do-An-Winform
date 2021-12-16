using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BEL;

namespace DAL
{
    public class DAL_SanPham:General
    {
        public DataTable docSanPham()
        {
            return XuLy("select * from SanPham where TrangThai=1");
        }
        public DataTable docSanPham(string maSP)
        {
            return XuLy("select * from SanPham where MaSp='" + maSP + "' and TrangThai = 1");
        }
        public DataTable docTenSanPham()
        {
            return XuLy("select TenSp from SanPham where TrangThai=1");
        }
        public DataTable docLoaiSanPham()
        {
            return XuLy("select * from LoaiSanPham");
        }
        public DataTable docNhaCungCap()
        {
            return XuLy("select * from NhaCungCap");
        }
        public string layMaSPMoi(string MaLoai,string MaNCC)
        {
            string stt = "";
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                SqlCommand cmd = new SqlCommand("select MAX(substring(MaSp,9,4))+1 from SanPham WHERE LEFT(MaSp,3)='"+MaLoai+"' and substring(MaSp,5,3)='"+MaNCC+"'", con);

                stt = cmd.ExecuteScalar().ToString(); //tra ve 1 ket qua duy nhat'cua cot dau` tien cua? hang dau`
            }
            catch (Exception)
            { }
            finally { con.Close(); }
            return "0" + stt;
        }
        public int themSanPham(SanPham sp)
        {
            return ThemSuaXoa("insert SanPham values('" + sp._maSP + "',N'" + sp._tenSP + "',N'" + sp._moTa + "'," + sp._soLuong + "," + sp._giaNhap + "," + sp._giaBan + ",'" + sp._ngayNhap.ToString("yyyy/MM/dd") + "','" + sp._maNCC + "','" + sp._loai + "','"+sp._trangThai+"','"+sp._uRL+"')");
        }
        public int capNhatSanPham(SanPham sp)
        {
            return ThemSuaXoa("UPDATE SanPham set TenSp=N'"+sp._tenSP+ "',MoTa=N'"+sp._moTa+ "',SoLuong="+sp._soLuong+ ",GiaNhap="+sp._giaNhap+ ",GiaBan="+sp._giaBan+ ",NgayNhap='"+sp._ngayNhap.ToString("yyyy/MM/dd") + "',TrangThai='"+sp._trangThai+ "',URL='"+sp._uRL+"'" +
                " where MaSp='"+sp._maSP+"'");
        }
    }
}
