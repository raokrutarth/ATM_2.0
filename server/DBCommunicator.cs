using System;
using QC = System.Data.SqlClient;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace AtmServer
{
    public class DBCommunicator
    {
        /* Using Data model gateway design pattern */
        enum RequestType { Query, Insert, Peek};
        public enum UpdateType { ID, fName, lName, h_pin, finger_path, face_path, balance };

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
            // ID     Fname     Lname     HPIN     HFINGER     HFACE     Balance
            Console.WriteLine("Filling Test DB");
            string fileName = @"..\..\TestDataFiles\MOCK_DATA.csv";           
            using (StreamReader reader= new StreamReader(fileName))
            {
                string newContent;
                while ( (newContent = reader.ReadLine()) != null)
                {
                    string[] fields = newContent.Split(',');
                    Console.WriteLine("Inserting entry:\n" +
                                      "Account No.: {0} " +
                                       "fName: {1} " +
                                       "lName: {2} " +
                                       "hpin: {3} " +
                                       "hface: {4} " +
                                       "hfinger: {5} " +
                                       "Balance: {6} ", Int64.Parse(fields[0]), fields[1], fields[2],
                                                        fields[3], fields[4], fields[5], Convert.ToDouble(fields[6].Trim('$') ) );
                    InsertEntry(connectionString, fields[0], fields[1], fields[2],
                                fields[3], fields[4], fields[5], Convert.ToDouble(fields[6].Trim('$') ) );                  
                }
                Console.ReadKey(true);
            }
        }

        public void printDB()
        {
            // ID     Fname     Lname     HPIN     HFINGER     HFACE     Balance   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {               
                SqlDataReader rdr = null;
                try
                {
                    connection.Open();                    
                    SqlCommand cmd = new SqlCommand("select * from dbo.TestCustomers order by Balance", connection);
                    rdr = cmd.ExecuteReader();                    
                    while (rdr.Read())
                    {
                        Console.Write("Customer ID = ");
                        Console.Write( rdr["CustomerID"].ToString() );
                        Console.Write(", FirstName = ");
                        Console.Write(rdr["FirstName"].ToString());
                        Console.Write(", Balance = ");
                        Console.WriteLine(rdr["Balance"].ToString());
                    }
                }
                catch (SqlException se)
                {
                    Console.WriteLine("SQL db not connected");
                    Console.WriteLine(se.Message);
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

        public bool InsertEntry(string connectionString, string CustID, string firstName, 
            string lastName, string hPin, string hFace, string hFinger, double balance)
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
        public bool update(string custID, UpdateType t, string data )
        {
            try
            {
                string query = "";
                int nUpdated = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd; // = new SqlCommand(query, conn)
                    if (t == UpdateType.fName)
                    {
                        // new Guid(CustID.PadLeft(32, '0')
                        query = "UPDATE dbo.TestCustomers SET FirstName=@NewName, Address=@NewAddress WHERE CustomerID=@Id";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", 1);
                        cmd.Parameters.AddWithValue("@Name", "Munna Hussain");
                        cmd.Parameters.AddWithValue("@Address", "Kerala");                        
                        // update first name
                    }                       
                    else if (t == UpdateType.lName)
                        // update last name
                        return true;
                    else if (t == UpdateType.balance)
                        // update balance
                        return true;
                    else if (t == UpdateType.h_pin)
                        // update hash_pin
                        return true;
                    else if (t == UpdateType.finger_path)
                        // update HFinger field in database
                        return true;
                    else if (t == UpdateType.face_path)
                        // update HFace field 
                        return true;
                    else
                    {
                        Console.WriteLine("[-] Invalid update type requested in db.update()");
                        return false;
                    }
                    nUpdated = cmd.ExecuteNonQuery();
                    if(nUpdated > 0)
                    {
                        Console.WriteLine("[+] " + nUpdated + " entries updated in update() ");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("[-] " + nUpdated + " entries updated in update() ");
                        Console.WriteLine("query_str = " + query);
                        return false;
                    }
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL exception in update()");
                Console.WriteLine(ex.Message);
                return false;
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
            Console.WriteLine("testDbconnection called()");
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
