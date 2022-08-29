using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connected
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sqlcon = "Data Source=DESKTOP-S8BF64H\SQLEXPRESS; Initial Catalog=master; Integrated security=SSPI";

           using(SqlConnection con =new SqlConnection(sqlcon))
            {
                string query = "select * from customer1";
                SqlCommand cmdobj = new SqlCommand();
                con.open();
                cmdobj.ExecuteReader();
                
            }
        }
    }
}
