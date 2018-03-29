using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ZipCodeAggregator
{
    class Connection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=IT-JW-10\\SQLEXPRESSJUSTIN;Initial Catalog=SandBox;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
