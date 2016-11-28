using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtmServer
{
    class ServerController
    {  
        public ServerController()
        {

        }
        void serveClient()
        {
            /// identify client ID
            /// assign new TCP communicator object
            /// assign new DBcomm object
            /// terminate connection when needed
        }
        bool saveEncryptedImage(string data)
        {
            // get the file from tcpcomm
            // encrypt file
            // store in local directory
            // update/insert the file path to db
            return true;
        }
        void recoverSession()
        {
            // plausible feature
        }
        static void testEncryption()
        {
            

            System.IO.DirectoryInfo diRoot = new System.IO.DirectoryInfo(System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "TestEncFiles") );

            Console.WriteLine("Write premission : " + IsDirectoryWritable(diRoot.FullName) );

            foreach ( var file in diRoot.GetFiles() )
            {
                Console.WriteLine("File: " + file.FullName);
                if (!file.FullName.EndsWith(".enc"))
                {
                    Console.WriteLine("Encrypting " + file.FullName);
                    string newName = file.FullName + ".enc";
                    Encryptor.EncryptFile(file.FullName, newName);
                }
            }
            Console.WriteLine("[+] files encrypted sucessfully, press any key to begin decryption");
            Console.ReadKey();

            foreach (var file in diRoot.GetFiles() )
            {
                string toDec = file.FullName;
                string fName = file.Name;
                if (toDec.Contains(".enc"))
                {                    
                    string orgName = fName.Remove(fName.IndexOf(".enc" ));
                    string newName = diRoot.FullName + "\\dec_" + orgName;                    
                    Encryptor.DecryptFile(toDec, newName);
                    Console.WriteLine("Decrypted " + toDec + " to " + newName);
                }                    
            }
            Console.WriteLine("[+] files decrypted sucessfully");
        }
        void testFace()
        {
            FaceIdentification fi = new FaceIdentification("<new Image Path>", "<custID>");
           while (true)
           {
               FaceIdentification.testRun();
           }
        }
        void testDB()
        {
            DBCommunicator dbComm = new DBCommunicator();

            dbComm.testDbConnection();
            //Console.WriteLine("Printing database...");
            //dbComm.printDB();

            string toChange = "00000000-0000-0000-3586-123193050990";
            Customer orgCust = dbComm.getCustomer(toChange);
            string newName = "Bob";
            Console.WriteLine("Before :");
            dbComm.getCustomer(toChange);
            Console.WriteLine("Changing " + toChange + " first name to " + newName);
            bool done = dbComm.update(toChange, DBCommunicator.UpdateType.fName, newName);
            Console.WriteLine("After :");
            dbComm.getCustomer(toChange);

            Console.WriteLine("Before :");
            dbComm.getCustomer(toChange);
            double nb = 500;
            Console.WriteLine("Changing " + toChange + " balance to to " + nb);
            done = dbComm.update(toChange, DBCommunicator.UpdateType.balance, nb.ToString());
            Console.WriteLine("After :");
            dbComm.getCustomer(toChange);

            Console.WriteLine("Before :");
            dbComm.getCustomer(toChange);
            string newFingerPath = orgCust.finger_path;
            newFingerPath += "/new/path/to/file,";
            Console.WriteLine("Changing " + toChange + " Finger file path to " + newFingerPath);
            done = dbComm.update(toChange, DBCommunicator.UpdateType.finger_path, newFingerPath);
            Console.WriteLine("After :");
            dbComm.getCustomer(toChange);
        }


        [STAThread]
        static void Main(string[] args)
        {
            int width = 200, height = 30;
            Console.SetWindowSize(width, height);
            Console.WriteLine("In ServerController Main()");            

            testEncryption();

            Console.ReadKey();
        }


        public static bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }
    }
}
