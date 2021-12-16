using System;
using System.Collections.Generic;
using System.Text;

namespace BEL
{
    public class CT_Hoadon
    {
        public string _maHd { get; set; }
        public string _maSP { get; set; }
        public  int _soLuong { get; set; }
        public string _giaBan { get; set; }
        public string _giamGia { get; set; }
        public string _chietKhau { get; set; }
        public string _thanhTien { get; set; }
        public CT_Hoadon()
        {
            _maHd = _maSP = _giaBan = _giamGia = _chietKhau = _thanhTien = "";
            _soLuong  = 0; ;
        }
        public CT_Hoadon(string mahd,string masp,int soluong,string giaban,string giamgia,string chietkhau,string thanhtien)
        {
            this._maHd = mahd;
            this._maSP = masp;
            this._soLuong = soluong;
            this._giaBan = giaban;
            this._giamGia = giamgia;
            this._chietKhau = chietkhau;
            this._thanhTien = thanhtien;
        }
    }
}
