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

        static string connectionString;
        

        public DBCommunicator()
        {
            /// Initilize communicator
            /// check connection with database
            /// check validity of  test data
            /// setup encryption
            connectionString = ConfigurationManager.ConnectionStrings["DBConnString"].ConnectionString;
        }
        public void FillDB()
        {
            // Create database if it doesn't exist
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var commandStr = @"If not exists (SELECT * FROM sys.tables WHERE name LIKE '#Customer%') 
                                    CREATE TABLE TestCustomers(CustomerID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,FirstName varchar(50),LastName varchar(50), HPIN 
                                    nvarchar,HFinger nvarchar,HFace nvarchar,Balance Money)";

                using (SqlCommand command = new SqlCommand(commandStr, con))
                {
                    if (command.ExecuteNonQuery() > 0)
                        Console.WriteLine("New db created");
                }
                con.Close();
            }

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
                    InsertEntry(fields[0], fields[1], fields[2],
                                fields[3], fields[4], fields[5], Convert.ToDouble(fields[6].Trim('$') ) );                  
                }
            }
        }

        public static void printDB()
        {
            // ID     Fname     Lname     HPIN     HFINGER     HFACE     Balance   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {               
                SqlDataReader rdr = null;
                try
                {
                    connection.Open();                    
                    SqlCommand cmd = new SqlCommand("select * from dbo.TestCustomers order by FirstName", connection);
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

        public static bool InsertEntry(string CustID, string firstName, 
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
                    try
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
                    catch (FormatException fe)
                    {
                        Console.WriteLine("Update called with invalid custID = " + CustID);
                        Console.WriteLine(fe.Message);
                        return false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Update called with invalid [NULL] custID :" + CustID);
                        return false;
                    }

                }
            }            
        }
        public static bool update(string custID, UpdateType t, string data )
        {
            try
            {
                string query = "";
                int nUpdated = 0;
                Guid f_custID = new Guid(custID); // new Guid(CustID.PadLeft(32, '0')
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd; // = new SqlCommand(query, conn)
                    if (t == UpdateType.fName)
                    {
                        // update first name
                        query = "UPDATE dbo.TestCustomers SET FirstName=@NewName WHERE CustomerID=@Id";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", f_custID);
                        cmd.Parameters.AddWithValue("@NewName", data);
                    }
                    else if (t == UpdateType.lName)
                    {
                        query = "UPDATE dbo.TestCustomers SET LastName=@NewName WHERE CustomerID=@Id";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", f_custID);
                        cmd.Parameters.AddWithValue("@NewName", data);
                    }
                    else if (t == UpdateType.balance)
                    {
                        query = "UPDATE dbo.TestCustomers SET Balance=@NewBalance WHERE CustomerID=@Id";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", f_custID);
                        double newBalance;
                        if (Double.TryParse(data, out newBalance))
                            cmd.Parameters.AddWithValue("@NewBalance", newBalance);
                        else
                            Console.WriteLine("{0} is outside the range of a Double in update()", newBalance);
                    }

                    else if (t == UpdateType.h_pin)
                    {
                        query = "UPDATE dbo.TestCustomers SET HPIN=@NewPin WHERE CustomerID=@Id";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", f_custID);
                        cmd.Parameters.AddWithValue("@NewPin", data);
                    }
                    else if (t == UpdateType.finger_path)
                    {
                        query = "UPDATE dbo.TestCustomers SET HFinger=@NewFingerPath WHERE CustomerID=@Id";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", f_custID);
                        cmd.Parameters.AddWithValue("@NewFingerPath", data);
                    }
                    else if (t == UpdateType.face_path)
                    {
                        query = "UPDATE dbo.TestCustomers SET HFace=@NewFacePath WHERE CustomerID=@Id";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", f_custID);
                        cmd.Parameters.AddWithValue("@NewFacePath", data);
                    }
                    else
                    {
                        Console.WriteLine("[-] Invalid update type requested in db.update()");
                        return false;
                    }

                    nUpdated = cmd.ExecuteNonQuery(); // execute the dynamically created query
                    if (nUpdated > 0)
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
            catch(FormatException fe)
            {
                Console.WriteLine("Update called with invalid custID = " + custID);
                Console.WriteLine(fe.Message);
                return false;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Update called with invalid [NULL] custID :" + custID);
                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL exception in update()");
                Console.WriteLine(ex.Message);
                return false;
            }    
        }


        public static bool remove(string custID, UpdateType t, string data)
        {
            return true;
        }
        public static Customer getCustomer(string custID)
        {
            Guid f_custID = new Guid(custID);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader rdr = null;
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TestCustomers WHERE CustomerID = @Id", connection);
                    cmd.Parameters.AddWithValue("@Id", f_custID);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer newCust = new Customer();

                        Console.Write("Customer ID : ");
                        newCust.CustomerID = new Guid(rdr["CustomerID"].ToString());
                        Console.Write(newCust.CustomerID.ToString());
                        
                        Console.Write(", FirstName : ");
                        newCust.FirstName = rdr["FirstName"].ToString();
                        Console.Write(newCust.FirstName);

                        Console.Write(", LastName : ");
                        newCust.LastName = rdr["LastName"].ToString();
                        Console.Write(newCust.LastName);

                        Console.Write(", HPin : ");
                        newCust.HPIN = rdr["HPIN"].ToString();
                        Console.Write(newCust.HPIN);

                        Console.Write(", finger_path : ");
                        newCust.finger_path = rdr["HFinger"].ToString();
                        Console.Write(newCust.finger_path);

                        Console.Write(", face_path : ");
                        newCust.face_path = rdr["HFace"].ToString();
                        Console.Write(newCust.face_path);

                        Console.Write(", Balance = ");
                        double newBalance = 0;
                        if ( Double.TryParse(rdr["Balance"].ToString(), out newBalance) )
                            newCust.balance = newBalance;
                        else
                            Console.WriteLine("{0} is outside the range of a Double in getCust()", newBalance);
                        Console.WriteLine(newCust.balance);
                        return newCust;
                    }
                }
                catch (SqlException se)
                {
                    Console.WriteLine("SQL db not connected");
                    Console.WriteLine(se.Message);
                    return null;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Update called with invalid custID = " + custID);
                    Console.WriteLine(fe.Message);
                    return null;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Update called with invalid [NULL] custID :" + custID);
                    return null;
                }
                finally
                {
                    if (rdr != null)
                        rdr.Close();
                    if (connection != null)
                        connection.Close();
                }
                return null;
            }            
        }
        public static bool testDbConnection()
        {
            Console.WriteLine("testDbconnection called()");
            using (var connection = new SqlConnection(connectionString))
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
