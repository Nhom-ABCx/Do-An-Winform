using System;
using System.Collections.Generic;
using System.Text;

namespace BEL
{
    public class SanPham
    {
        public string _maSP { get; set; }
        public string _tenSP { get; set; }
        public string _moTa { get; set; }
        public int _soLuong { get; set; }
        public int _giaNhap { get; set; }
        public int _giaBan { get; set; }
        public DateTime _ngayNhap { get; set; }
        public string _maNCC {get;set;}
        public string _loai { get; set; }
        public bool _trangThai { get; set; }
        public string _uRL { get; set; }
        public SanPham()
        {
            _maSP = _tenSP = _moTa = _maNCC = _loai = _uRL = "";
            _soLuong = _giaNhap = _giaBan = 0;
            _ngayNhap = DateTime.Today;
            _trangThai = false;
        }
        public SanPham(string masp,string tensp,string mota,int soluong,int gianhap,int giaban,DateTime ngaynhap,string mancc,string loai,bool trangthai,string url)
        {
            _maSP = masp;_tenSP = tensp; _moTa = mota;_soLuong = soluong;_giaNhap = gianhap;_giaBan = giaban; _ngayNhap = ngaynhap;
            _maNCC = mancc;_loai = loai;_trangThai = trangthai;_uRL = url;

        }
    }
}
