using System;
using QC = System.Data.SqlClient;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace AtmServer
{
    class DBCommunicator
    {
        /* Using Data model gateway design pattern */
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
            connectionString = ConfigurationManager.ConnectionStrings["DBConnString"].ConnectionString;
        }
        public void FillDB()
        {
            // Header
            // ID     Fname     Lname     HPIN     HFINGER     HFACE     Balance
            string fileName = @"..\..\TestDataFiles\MOCK_DATA.csv";           
            using (StreamReader reader= new StreamReader(fileName))
            {
                string newContent;
                while ( (newContent = reader.ReadLine()) != null)
                {
                    string[] fields = newContent.Split(',');

                    Console.WriteLine("Account No.: {0} " +
                                       "fName: {1} " +
                                       "lName: {2} " +
                                       "hpin: {3} " +
                                       "hface: {4} " +
                                       "hfinger: {5} " +
                                       "Balance: {6} ", fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6]);                    
                }
                Console.ReadKey(true);
            }


        }
        public void printDB()
        {
            string queryString = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader rdr = null;
                try
                {
                    connection.Open();                    
                    SqlCommand cmd = new SqlCommand("select * from Customers", connection);
                    rdr = cmd.ExecuteReader();                    
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                    }
                }
                finally
                {                    
                    if (rdr != null)
                        rdr.Close();
                    if (connection != null)
                        connection.Close();
                }
            }
        }

        public bool insert(string dataType, string data) // switch data to array/list type
        {
            // create insert query
            return true;
        }
        public bool remove(string dataType, string data)
        {
            return true;
        }
        public string getData(string DataType, string request)
        {
            return null;
        }
        public bool testDbConnection()
        {
            Console.WriteLine("testDb called()");
            using (var connection = new QC.SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("DB Connected successfully.");
                connection.Close();
                return true;               
            }
        }
        
        ~DBCommunicator()
        {
            Console.WriteLine("DBCommunicator object terminated");
        }
    }
}
