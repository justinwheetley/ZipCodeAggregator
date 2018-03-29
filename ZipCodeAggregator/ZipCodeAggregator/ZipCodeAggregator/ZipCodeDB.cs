using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ZipCodeAggregator
{
    class ZipCodeDB
    {
        public static void AddZipInfo(ZipCode zipCode)
        {
            SqlConnection connection = Connection.GetConnection();
            string insertStatement =
                "INSERT INTO ZipCodeInfoTable " +
                "(City, State, ZipCode, AreaCode, TimeZone) " +
                "VALUES (@City, @State, @ZipCode, @AreaCode, @TimeZone)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@City", zipCode.City);
            insertCommand.Parameters.AddWithValue(
                "@State", zipCode.State);
            insertCommand.Parameters.AddWithValue(
                "@ZipCode", zipCode.ZipC);
            insertCommand.Parameters.AddWithValue(
                "@AreaCode", zipCode.AreaCode);
            insertCommand.Parameters.AddWithValue(
                "@TimeZone", zipCode.TimeZone);

            connection.Open();
            insertCommand.ExecuteNonQuery();

            MessageBox.Show("Data Successfully written to database.");

            connection.Close();
            
        }
    }
}
