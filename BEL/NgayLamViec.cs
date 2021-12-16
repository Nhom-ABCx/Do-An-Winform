using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NgayLamViec
    {
        public DateTime _ngay { get; set; }
        public string _maNV { get; set; }
        public DateTime _gioBD { get; set; }
        public DateTime _gioKT { get; set; }
        public int _soGio { get; set; }
        public NgayLamViec()
        {
            _ngay = DateTime.Today;
            _gioBD = _gioKT = DateTime.Now;
            _maNV = null;_soGio = 0;
        }
    }
}
