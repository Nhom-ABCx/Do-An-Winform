using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using BEL;

namespace DAL
{
    public class DAL_NhaCungCap:General
    {
        public DataTable docNhaCungCap()
        {return XuLy("select * from NhaCungCap");}
        public int themNhaCungCap(NhaCungCap ncc)
        {
            return ThemSuaXoa("insert NhaCungCap values('" + ncc._maNcc + "',N'" + ncc._tenNcc + "',N'" + ncc._diaChi + "'," + ncc._phone + ",'" + ncc._email + "')");
        }
        public int capNhatNhaCungCap(NhaCungCap ncc)
        {
            return ThemSuaXoa("UPDATE NhaCungCap set TenNcc=N'" + ncc._tenNcc + "',Diachi=N'" + ncc._diaChi + "',Phone=" + ncc._phone + ",eMail='" + ncc._email + "'" +
                " where MaNcc='" + ncc._maNcc + "'");
        }
    }
}
