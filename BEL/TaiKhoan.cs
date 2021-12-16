using System;
using System.Collections.Generic;
using System.Text;

namespace BEL
{
    public class TaiKhoan
    {   
        public string _maTK { get; set; }
        public string _maLoai { get; set; }
        public string _email { get; set; }
        public string _matKhau { get; set; }
        public string _phone { get; set; }
        public DateTime _ngayTao { get; set; }
        public bool _trangThai { get; set; }
        public TaiKhoan()
        {
            _maTK = _maLoai = _email = _matKhau = _phone = "";
           _ngayTao = DateTime.Parse("1/1/2021");
            _trangThai = false;
        }
        public TaiKhoan(string tkDN, string matkhau)
        {
            _email = _phone = tkDN; _matKhau = matkhau;
        }
        public TaiKhoan(string maTK,string maLoai,string email,string matKhau, string phone,DateTime ngayTao,bool trangThai)
        {
            _maTK = maTK;_maLoai = maLoai;_email = email;_matKhau = matKhau;_phone = phone;_ngayTao = ngayTao;_trangThai = trangThai;
        }
    }
}
