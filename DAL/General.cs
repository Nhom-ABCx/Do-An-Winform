using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class General
    {
        //string.Format("Xác nhận thanh toán cho {0}\n Tổng tiền -(tổng tiền /100)x Giảm giá => {1} - ( {1} /100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice)
        //link nay`la den sql sever
        public SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=CSDL_BanHang;Integrated Security=True");
        //Properties.Settings.Default.QLBanHangConnectionString
        //link nay`la den database noi bo cua thu muc
        //public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\DATA\\CSDL_BanHang.mdf;Integrated Security=True");
        //System.IO de doc lien ket den thu muc
        public DataTable XuLy(string sql)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int ThemSuaXoa(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (con.State != ConnectionState.Open)
                    con.Open();

                int kq = cmd.ExecuteNonQuery();

                if (con.State != ConnectionState.Closed)
                    con.Close();
                return kq;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
