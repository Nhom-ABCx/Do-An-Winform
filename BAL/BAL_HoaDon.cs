using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using DAL;
using BEL;

namespace BAL
{
    public class BAL_HoaDon:General
    {
        DAL_HoaDon dAL_HoaDon = new DAL_HoaDon();
        public DataTable DocHoaDon()
        {
            return dAL_HoaDon.docHoaDon();
        }
        public DataTable DocHoaDonTrangThai0()
        {
            return dAL_HoaDon.docHoaDonTrangThai0();
        }
        public DataTable DocHoaDonTrangThai1()
        {
            return dAL_HoaDon.docHoaDonTrangThai1();
        }
        public DataTable DocTTHoaDon(string mahd)
        {
            return dAL_HoaDon.docTTHoaDon(mahd);
        }
        public DataTable DocTTct_HoaDon(string mahd)
        {
            return dAL_HoaDon.docTTct_HoaDon(mahd);
        }
        public string LoadTTHoaDon(string mahd, DataGridView dgv,GroupBox grp)
        {
            long tongtien=0;
            try
            {
                if (ConnectionState.Closed == con.State)
                    con.Open();
                foreach (DataRow row in dAL_HoaDon.docTTct_HoaDon(mahd).Rows)
                {
                    string masp = row["MaSp"].ToString();
                    string tensp = row["TenSp"].ToString();
                    string soluong = row["SoLuong"].ToString();
                    //tach'ra cho mat con so' 0 cua kieu Money
                    string[] temp = row["GiaBan"].ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string giaban = "";
                    if (temp.Length > 0)
                        giaban = temp[0];

                    temp = row["GiaGiam"].ToString().Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string giagiam = "";
                    if (temp.Length > 0)
                        giagiam = temp[0];

                    string chietkhau = row["ChietKhau"].ToString();

                    string thanhtien = ((int.Parse(soluong) * long.Parse(giaban))- (int.Parse(soluong) * long.Parse(giaban)*int.Parse(chietkhau))-long.Parse(giagiam)).ToString();
                     tongtien += long.Parse(thanhtien);
                    dgv.Rows.Add(masp,tensp, soluong, giaban, thanhtien);
                    string trangthai = row["TrangThai"].ToString();
                    if (trangthai == "True")
                        grp.Text = "Mã HĐ - Đã thanh toán";
                    else grp.Text = "Mã HĐ - Chưa thanh toán";
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(err.ToString(), "", MessageBoxButtons.OK);
                throw;
            }
            finally { con.Close(); }
            return tongtien.ToString("N0");
        }
        public bool TrangThaiHD(string mahd)
        { return dAL_HoaDon.TrangThaiHD(mahd); }
        public int ThemCT_HoaDon(string mahd,string masp,int soluong,int giagiam,int chietkhau)
        {
            return dAL_HoaDon.themCT_HoaDon(mahd,masp,soluong,giagiam,chietkhau);
        }
        public int CapNhatCT_HoaDon(DataGridView dgv,string mahd, string masp, int soluong, int giagiam, int chietkhau)
        {
            int soLuongCu=int.Parse(dgv["SoLuong", dgv.CurrentRow.Index].Value.ToString());
            int soLuongUpdateSP = soluong - soLuongCu;
            return dAL_HoaDon.capNhatCT_HoaDon(mahd,masp,soluong,soLuongUpdateSP,giagiam,chietkhau);
        }
        public int XoaCT_HoaDon(DataGridView dgv,string mahd,string masp)
        {
            int soLuongUpdateSP = int.Parse(dgv["SoLuong", dgv.CurrentRow.Index].Value.ToString());
            return dAL_HoaDon.xoaCT_HoaDon(mahd, masp, soLuongUpdateSP);
        }
        public int ThemHoaDon(HoaDon hd)
        {
            return dAL_HoaDon.themHoaDon(hd);
        }
        public int CapNhatHoaDon(HoaDon hd)
        {
            return dAL_HoaDon.capNhatHoaDon(hd);
        }
        public int XoaHoaDon(string  mahd)
        {
            return dAL_HoaDon.xoaHoaDon(mahd);
        }
        public int ThanhToanHD(string mahd)
        {
            return dAL_HoaDon.thanhToanHD(mahd);
        }
    }
}
