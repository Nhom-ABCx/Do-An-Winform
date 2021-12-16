using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NhanVien
    {
        public string _maNV { get; set; }
        public string _hotenNV { get; set; }
        public DateTime _ngaySinh { get; set; }
        public string _gioiTinh { get; set; }
        public string _diaChi { get; set; }
        public string _maTK { get; set; }
        public int _luongCB { get; set; }
        public int _tongGioLam { get; set; }
        public bool _trangThai { get; set; }

        public NhanVien()
        {
            _maNV = _hotenNV = _gioiTinh = _diaChi = _maTK = null;
            _ngaySinh = DateTime.Today;
            _luongCB = _tongGioLam =  0;
            _trangThai = false;
        }
        public NhanVien(string manv,DateTime ngaysinh,string gioitinh,string diachi,string matk,int luongcb,int tonggiolam,bool trangthai)
        {
            _maNV = manv;_ngaySinh = ngaysinh;_gioiTinh = gioitinh;_diaChi = diachi;_maTK = matk;_luongCB = luongcb;_tongGioLam = tonggiolam;_trangThai = trangthai;
        }
    }
}
