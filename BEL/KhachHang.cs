using System;
using System.Collections.Generic;
using System.Text;

namespace BEL
{
    public class KhachHang
    {

        public string _maKH { get; set; }
        public string _hoTenKH { get; set; }
        public string _diaChi { get; set; }
        public string _maTK{get;set;}
        public bool _trangThai { get; set; }

        public KhachHang()
        {
            _maKH = _hoTenKH = _diaChi = _maTK = "";
            _trangThai = false;
        }
        public KhachHang(string _maKH,string _hoTenKH,string _diaChi,string _maTK,bool _trangThai)
        {
            this._maKH = _maKH;
            this._hoTenKH = _hoTenKH;
            this._diaChi = _diaChi;
            this._maTK = _maTK;
            this._trangThai = _trangThai;
        }
    }
}
