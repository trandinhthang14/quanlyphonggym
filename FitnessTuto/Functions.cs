using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTuto
{
    
    internal class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable dt;
        private string ConStr;
        private SqlDataAdapter sda;

        public Functions()
        {
            ConStr = @"Data Source=LAPTOP-36CG3J2Q\Thang;Initial Catalog=FitnessDB;Integrated Security=True";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }
        public int setData(string Query) 
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }
    }
}
