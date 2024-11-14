using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanrlymaybay
{
    internal class Ketnoi
    {
        string conStr = @"Data Source=LAPTOP-2OPVKRUR\SQLEXPRESS;Initial Catalog=quản lý máy bay;Integrated Security=True";
        SqlConnection conn;
        public KetNoi()
        {
            conn = new SqlConnection(conStr);
        }
        public DataSet LayDuLieu(string truyvan)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(truyvan, conn);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null!;
            }
        }
        public bool ThucThi(string truyvan)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(truyvan, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
