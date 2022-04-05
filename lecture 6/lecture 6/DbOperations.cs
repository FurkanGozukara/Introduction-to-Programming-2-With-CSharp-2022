using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace lecture_6
{
    public static class DbOperations
    {
        //to learn your server name execute this command select @@servername
        private static string srConnectionString = @"server=DESKTOP-ULH4M26;database=School; integrated security=SSPI;persist security info=False; Trusted_Connection=Yes;";

        public static DataTable selectTable(string srQuery)
        {
            DataTable dtReturnTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(srConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter DA = new SqlDataAdapter(srQuery, connection))
                    {
                        DA.Fill(dtReturnTable);
                    }
                }
            }
            catch (Exception E)
            {
                logSQLErrors(srQuery, E);
            }

            return dtReturnTable;
        }

        private static void logSQLErrors(string srQuery, Exception E)
        {
            File.AppendAllText("SQLerrors.txt", "SQL error: Query= " + srQuery + " Error: " + E?.Message + "\r\n" + E?.InnerException?.ToString() + "\r\n\r\n");
        }

    }
}
