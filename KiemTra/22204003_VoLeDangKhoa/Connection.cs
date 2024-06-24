using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22204003_VoLeDangKhoa
{
    internal class Connection
    {
        string strconn = @"Data Source=DESKTOP-B98QTTF\SQLEXPRESS;Initial Catalog=QLLKDT;Integrated Security=True";
        SqlConnection conn;

        public Connection()
        {
            conn = new SqlConnection(strconn);
        }

        public DataTable GetData(string query)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public int ExcuteQuery(string query)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            int kq = 0;
            try
            {
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            conn.Close();
            return kq;
        }

        public object CheckedQuery(string query)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            object kq = 0;
            try
            {
                kq = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
            }
            conn.Close();
            return kq;
        }
    }
}
