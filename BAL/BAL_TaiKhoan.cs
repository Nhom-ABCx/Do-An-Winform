using System;
using System.Data;
using System.Data.SqlClient;
using BEL;
using DAL;
namespace BAL
{
    public class BAL_TaiKhoan
    {
        DAL_TaiKhoan dalTK = new DAL_TaiKhoan();
        public DataTable DocTK(TaiKhoan tk,NhanVien nv,NgayLamViec nlv)
        {
            foreach (DataRow row in dalTK.docTK(tk).Rows)
            {
                tk._maTK = row["MaTK"].ToString();
                tk._maLoai = row["MaLoai"].ToString();
                tk._email = row["eMail"].ToString();
                tk._matKhau = row["MatKhau"].ToString();
                tk._phone = row["Phone"].ToString();
                tk._ngayTao = DateTime.Parse(row["NgayKhoiTao"].ToString());
                tk._trangThai = bool.Parse(row["TrangThai"].ToString());

                nv._maNV = row["MaNV"].ToString();
                nv._hotenNV = row["HoTenNV"].ToString();
                nv._ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                nv._gioiTinh = row["GioiTinh"].ToString();
                nv._diaChi = row["DiaChi"].ToString();
                nv._maTK = row["MaTK"].ToString();

                string[] temp = row["LuongCB"].ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (temp.Length > 0)
                    nv._luongCB = int.Parse(temp[0]);
                if (row["TongGioLam"].ToString() == "")
                    nv._tongGioLam = 0;
                else nv._tongGioLam = int.Parse(row["TongGioLam"].ToString());
                nv._trangThai = bool.Parse(row["TrangThai"].ToString());

                nlv._ngay = DateTime.Today;
                nlv._maNV = row["MaNV"].ToString();
                nlv._gioBD = DateTime.Now;
            }
            return dalTK.docTK(tk);
        }
        public DataTable DocDSTaiKhoan()
        {
            return dalTK.docDSTaiKhoan();
        }
        public DataTable DocDSLoaiNV()
        {
            return dalTK.docDSLoaiTKNV();
        }
        public DataTable DocDSLoaiKH()
        {
            return dalTK.docDSLoaiTKKH();
        }
        public int TinhNgayLam(NhanVien nv,NgayLamViec nlv)
        {
            return dalTK.tinhNgayLam(nv, nlv);
        }
        public int KetThucNgayLam(NhanVien nv,NgayLamViec nlv)
        {
            return dalTK.ketThucNgayLam(nv, nlv);
        }
        public string TaoMaTaiKhoanMoi(string MaLoai,string SoThuTu)
        {
            return dalTK.taoMaTaiKhoanMoi(MaLoai,SoThuTu);
        }
        public int ThemTaiKhoan(TaiKhoan tk)
        {
            return dalTK.themTaiKhoan(tk);
        }
    }
}
