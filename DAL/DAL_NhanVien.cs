using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using BEL;

namespace DAL
{
    public class DAL_NhanVien : General
    {
        public DataTable docNhanVien()
        {
            return XuLy("select * from NhanVien");
        }
        public DataTable docNhanVienTrangThai0()
        {
            return XuLy("select * from NhanVien where TrangThai=0");
        }
        public DataTable docNhanVienTrangThai1()
        {
            return XuLy("select * from NhanVien where TrangThai=1");
        }
        public string layMaNVMoi()
        {
            string stt = "";
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                SqlCommand cmd = new SqlCommand("select MAX(manv)+1 from nhanvien", con);

                stt = cmd.ExecuteScalar().ToString(); //tra ve 1 ket qua duy nhat'cua cot dau` tien cua? hang dau`
            }
            catch (Exception)
            { }
            finally { con.Close(); }
            return "0"+stt;
        }
        public int themNhanVien(NhanVien nv)
        {
            return ThemSuaXoa("insert NhanVien values('"+nv._maNV+"',N'"+nv._hotenNV+"','"+nv._ngaySinh.ToString("yyyy/MM/dd")+"',N'"+nv._gioiTinh+"',N'"+nv._diaChi+"','"+nv._maTK+"',"+nv._luongCB+","+nv._tongGioLam+",'"+nv._trangThai+ "')");
        }
        public int capNhatNhanVien(NhanVien nv)
        {
            return ThemSuaXoa("UPDATE NhanVien set HoTenNV=N'"+nv._hotenNV+"',NgaySinh='"+ nv._ngaySinh.ToString("yyyy/MM/dd") + "',GioiTinh=N'"+ nv._gioiTinh + "',DiaChi=N'"+ nv._diaChi + "',MaTK='"+ nv._maTK + "',LuongCB="+nv._luongCB+",TrangThai='"+ nv._trangThai + "'" +
                "where MaNV='"+nv._maNV+"'");
        }
    }
}
