using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using QC = System.Data.SqlClient;
using System.Data.SqlClient;

namespace AtmServer
{
    class DBCommunicator
    {
        enum RequestType { Query, Insert, Peek};
        string connectionString;

        public DBCommunicator()
        {
            /// Initilize communicator
            /// check connection with database
            /// check validity of  test data
            /// setup encryption
            /// return true on sucess
            /// 
            connectionString = "Server=tcp:atm20customer.database.windows.net,1433;" +
                "Initial Catalog=CustomerDatabase;Persist Security Info=False;User ID=atm20team;" +
                    "Password=CS307project;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;" +
                        "Connection Timeout=30;";
        }
        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader rdr = null;
                try
                {
                    connection.Open();

                    // 3. Pass the connection to a command object
                    SqlCommand cmd = new SqlCommand("select * from Customers", connection);
                    //
                    // 4. Use the connection
                    //
                    // get query results
                    rdr = cmd.ExecuteReader();
                    // print the CustomerID of each record
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                    }
                }
                finally
                {
                    // close the reader
                    if (rdr != null)
                    {
                        rdr.Close();
                    }

                    // 5. Close the connection
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void testDb()
        {
            Console.WriteLine("testDb called()");
            using (var connection = new QC.SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connected successfully.");

                Console.WriteLine("Press any key to finish...");
                Console.ReadKey(true);
            }
        }
        
        ~DBCommunicator()
        {
            Console.WriteLine("DBCommunicator object terminated");
        }
    }
}
