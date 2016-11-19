using System;
using QC = System.Data.SqlClient;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Filling Test DB");
            string fileName = @"..\..\TestDataFiles\MOCK_DATA.csv";           
            using (StreamReader reader= new StreamReader(fileName))
            {
                string newContent;
                while ( (newContent = reader.ReadLine()) != null)
                {
                    string[] fields = newContent.Split(',');

                    /*Console.WriteLine("Account No.: {0} " +
                                       "fName: {1} " +
                                       "lName: {2} " +
                                       "hpin: {3} " +
                                       "hface: {4} " +
                                       "hfinger: {5} " +
                                       "Balance: {6} ", fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6]); */                 

                    Console.WriteLine("Inserting entry:\n" +
                                      "Account No.: {0} " +
                                       "fName: {1} " +
                                       "lName: {2} " +
                                       "hpin: {3} " +
                                       "hface: {4} " +
                                       "hfinger: {5} " +
                                       "Balance: {6} ", Int64.Parse(fields[0]), fields[1], fields[2],
                                                        fields[3], fields[4], fields[5], Convert.ToDouble(fields[6].Trim('$')));

                    InsertData(connectionString, fields[0], fields[1], fields[2],
                                fields[3], fields[4], fields[5], Convert.ToDouble(fields[6].Trim('$')));                  
                }
                Console.ReadKey(true);
            }


        }

        private int TryParse(string v, int int32)
        {
            throw new NotImplementedException();
        }

        public void printDB()
        {
            string queryString = null;
            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                SqlDataReader rdr = null;
                try
                {
                    connection.Open();                    
                    SqlCommand cmd = new SqlCommand("select * from dbo.TestCustomers", connection);
                    rdr = cmd.ExecuteReader();                    
                    while (rdr.Read())
                    {
                        Console.WriteLine("Reading from DB...");
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
            }*/
        }

        public bool InsertData(string connectionString, string CustID, string firstName, string lastName, string hPin, string hFace,
                        string hFinger, double balance)
        {
            // define INSERT query with parameters
            string query = "INSERT INTO dbo.TestCustomers (CustomerID, FirstName, LastName, HPIN, HFinger, HFace, Balance) " +
                           "VALUES (@CustomerID, @FirstName, @LastName, @HPIN, @HFinger, @HFace, @Balance) ";

            // create connection and command
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                Console.WriteLine("DB Connected successfully.");
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // define parameters and their values
                    cmd.Parameters.Add("@CustomerID", SqlDbType.UniqueIdentifier).Value = new Guid(CustID.PadLeft(32, '0'));
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
                    cmd.Parameters.Add("@HPIN", SqlDbType.NVarChar).Value = hPin;
                    cmd.Parameters.Add("@HFinger", SqlDbType.NVarChar).Value = hFinger;
                    cmd.Parameters.Add("@HFace", SqlDbType.NVarChar).Value = hFace;
                    cmd.Parameters.Add("@Balance", SqlDbType.Money).Value = balance;

                    // open connection, execute INSERT, close connection
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    return true;
                }
            }            
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

        public static bool GuidTryParse(string s, out Guid result)
        {
            if (!String.IsNullOrEmpty(s) && guidRegEx.IsMatch(s))
            {
                result = new Guid(s);
                return true;
            }
            result = default(Guid);
            return false;
        }
        static Regex guidRegEx = new Regex("^[A-Fa-f0-9]{32}$|" +
                              "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                              "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, "+ 
                              "{0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$", RegexOptions.Compiled);
    }
}
