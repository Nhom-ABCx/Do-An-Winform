using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BEL;

namespace DAL
{
    public class DAL_KhachHang : General
    {
        public DataTable docKhachHang()
        {
            return XuLy("select * from KhachHang");
        }
        public string layMaKHMoi()
        {
            string stt = "";
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                SqlCommand cmd = new SqlCommand("select MAX(makh)+1 from khachhang", con);

                stt = cmd.ExecuteScalar().ToString(); //tra ve 1 ket qua duy nhat'cua cot dau` tien cua? hang dau`
            }
            catch (Exception)
            { }
            finally { con.Close(); }
            return "0" + stt;
        }
        public int themKhachHang(KhachHang kh)
        {
            return ThemSuaXoa("insert into KhachHang values('" + kh._maKH + "',N'" + kh._hoTenKH + "',N'" + kh._diaChi + "','" + kh._maTK + "','" + kh._trangThai + "')");
        }
        public int capNhatKhachHang(KhachHang kh)
        {
            return ThemSuaXoa("update KhachHang set HoTenKh=N'" + kh._hoTenKH + "',DiaChi=N'" + kh._diaChi + "',MaTK=N'" + kh._maTK + "',TrangThai=N'" + kh._trangThai + "' where MaKh='" + kh._maKH + "'");
        }
        public DataTable TimKiemTheoMa(string chuoiTimKiem)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                SqlCommand cmd = new SqlCommand("tbl_KhachHang_TimKiemKHThemMa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("MaKh", SqlDbType.NVarChar)).Value = chuoiTimKiem;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            { }
            finally { con.Close(); }
            return dt;
        }

        public DataTable TimKiemTheoTen(string chuoiTimKiem)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == con.State)
                con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("tbl_KhachHang_TimTheoKHTheoTen", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("TenKh", SqlDbType.NVarChar)).Value = chuoiTimKiem;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            { }
            finally { con.Close(); }
            return dt;
        }
    
    }
    
}
