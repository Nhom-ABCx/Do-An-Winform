using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NhaCungCap
    {
        public string _maNcc { get; set; }
        public string _tenNcc { get; set; }
        public string _diaChi { get; set; }
        public string _phone { get; set; }
        public string _email { get; set; }

        public NhaCungCap()
        {
            this._maNcc = this._tenNcc = this._diaChi = this._phone = this._email = "";
        }
        public NhaCungCap(string _maNcc,string _tenNcc,string _diaChi,string _phone,string _email)
        {
            this._maNcc = _maNcc;this._tenNcc = _tenNcc;this._diaChi = _diaChi;this._phone = _phone;this._email = _email;
        }
    }
}
