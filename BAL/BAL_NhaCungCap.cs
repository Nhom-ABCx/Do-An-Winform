using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using BEL;
using DAL;

namespace BAL
{
    public class BAL_NhaCungCap
    {
        DAL_NhaCungCap dalNCC = new DAL_NhaCungCap();
        public DataTable DocNhaCungCap()
        { return dalNCC.docNhaCungCap(); }
        public int ThemNhaCungCap(NhaCungCap NCC)
        {return dalNCC.themNhaCungCap(NCC);}
        public int CapNhatNhaCungCap(NhaCungCap NCC)
        {return dalNCC.capNhatNhaCungCap(NCC);}
    }
}
