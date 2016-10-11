using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AtmServer
{
    class DBCommunicator
    {
        enum RequestType { Query, Insert, Peek};

        public DBCommunicator()
        {
            /// Initilize communicator
            /// check connection with database
            /// check validity of  test data
            /// setup encryption
            /// return true on sucess
            /// 
            string connectionString = "Server=tcp:atm20customer.database.windows.net,1433;Initial Catalog=CustomerDatabase;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            CreateCommand("", connectionString);

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
        
        ~DBCommunicator()
        {
            Console.WriteLine("DBCommunicator object terminated");
        }
    }
}
