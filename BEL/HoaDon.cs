using System;
using System.Collections.Generic;
using System.Text;

namespace BEL
{
    public class HoaDon
    {
        public string _maHD { get; set; }
        public DateTime _ngayLapHD { get; set; }
        public string _maNV { get; set; }
        public string _maKH { get; set; }
        public string _diaChiGiao { get; set; }
        public string _tongTien { get; set; }
        public bool _trangThai { get; set; }
        public HoaDon()
        {
            _maHD = _maNV = _maKH = _diaChiGiao = _tongTien="";
            _ngayLapHD = DateTime.Now;
            _trangThai = false;
        }
        public HoaDon(string _maHD, DateTime _ngayLapHD, string _maNV, string _maKH, string _diaChiGiao,string _tongTien, bool _trangThai)
        {
            this._maHD = _maHD;
            this._ngayLapHD = _ngayLapHD;
            this._maNV = _maNV;
            this._maKH = _maKH;
            this._diaChiGiao = _diaChiGiao;
            this._tongTien = _tongTien;
            this._trangThai = _trangThai;
        }
    }
}
