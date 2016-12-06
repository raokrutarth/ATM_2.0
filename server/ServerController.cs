using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace AtmServer
{
	//Delegates for Callback Functions
	public delegate bool TCPDataCallback(ClientData clientData, Command command);
	public delegate string TCPCustomerCallback(ClientData clientData, string data);

	class ServerController
    {  
    	public static ServerController currentController;

		// Member fields.
		Dictionary<string, TCPDataCallback> callbacks;
		Dictionary<string, TCPCustomerCallback> customerCallbacks;
		public DBCommunicator database;
		public Authenticator auth;
		public TCPCommunicator tcp;


		public ServerController() {
			currentController = this;
			this.callbacks = new Dictionary<string, TCPDataCallback>();
			this.customerCallbacks = new Dictionary<string, TCPCustomerCallback>();
			this.database = new DBCommunicator();
			this.auth = new Authenticator();
			this.tcp = new TCPCommunicator();
		}
        
		//executes the command given by the client
        public void executeCommand(ClientData clientData, Command command)
        {
			// Call our callback here.
			if (this.callbacks.ContainsKey(command.command)) {
				Console.WriteLine("Calling the callback: {0}", command.command);
				bool success = this.callbacks[command.command](clientData, command);

			} else if (this.customerCallbacks.ContainsKey(command.command)) {
				string response = this.customerCallbacks[command.command](clientData, command.data);
				Command cmd = new Command("Response", response);
				ServerController.currentController.tcp.Send(cmd);

			} else {
				Console.WriteLine("ERROR: Invalid message name received.");
				Console.WriteLine("Name: {0} {1}", command.command, command.command.Length);
			}
		}

		//registers callback functions
		public bool RegisterCallback(string dataType, TCPDataCallback callback) {
			this.callbacks[dataType] = callback;
			return true;
		}

		//registers callbacks for Customer class
		public bool registerCustomerCallback (string dataType, TCPCustomerCallback callback) {
			this.customerCallbacks[dataType] = callback;
			return true;
		}


        bool saveEncryptedImage(string data)
        {
            // get the file from tcpcomm
            // encrypt file
            // store in local directory
            // update/insert the file path to db
            return true;
        }

		//Test methods
        static void testEncryption()
        {
            DirectoryInfo diRoot = new System.IO.DirectoryInfo(System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "FaceVerifyTest\\Rao") );

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
        static async void testFace(bool valid)
        {
            
            //while (true)
            //{
            //    FaceIdentification.testRun();
            //}
           DirectoryInfo diRoot = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FaceVerifyTest"));

            Random rnd = new Random();
            int randValid = rnd.Next(4);
            string tested;

            foreach (var folder in diRoot.GetDirectories())
            {
                //Getting all training images and put into a list
                DirectoryInfo di = new System.IO.DirectoryInfo(folder.FullName);
                Console.WriteLine("in folder: " + folder.FullName);
                List<string> imageFiles = new List<string>();
                di.GetFiles().ToList().ForEach(f => imageFiles.Add(f.FullName));

                // dhoni, duterte & rao are seperate paths to valid files
                // used to verify against the base files provided above.
                string[] validFaces = new string[] {
                @".\FaceVerifyTest\msd_verify.jpg",
                @".\FaceVerifyTest\duterte_verify2.jpg",
                @".\FaceVerifyTest\duterte_verify.jpg",
                @".\FaceVerifyTest\rao_verify.png" };
               
                if(valid)   // test valid verification image against base images
                    tested = validFaces[randValid];
                else // rickey doesn't exist in any base image folder so it should evaluate to false for all folders
                    tested = @".\FaceVerifyTest\rickey_verify.jpg";

                Console.WriteLine("testing with image " + tested);
                bool detected;
                try
                {
                    detected = await FaceIdentification.verifyFace(tested, imageFiles, folder.Name);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occured wehn FaceIdentification.verifyFace() called");
                    Console.WriteLine(e.Message);
                    if(e.InnerException != null)
                        Console.WriteLine(e.InnerException.Message);
                    continue;
                }                                
                Console.WriteLine("[+] " + tested.Substring(tested.LastIndexOf('\\')+1) + " detected in base files: " + detected );
                //Thread.Sleep(3000);          
            }
        }
        static string getTestFilePaths()
        {
            string[] UnEncFiles = {
                @".\FaceVerifyTest\Duterte\dt-1.jpg",
                @".\FaceVerifyTest\Duterte\dt-3.jpg",
                @".\FaceVerifyTest\Duterte\rodrigo-duterte-2.jpg",
                @".\FaceVerifyTest\Duterte\rodrigo-duterte-5.jpg",
                @".\FaceVerifyTest\Duterte\RodrigoDuterte4.jpg"
            };
            string res = "";
            int n = 0;
            foreach (string encFile in UnEncFiles)
            {
                string newPath = Directory.GetCurrentDirectory() + "\\duterte_baseFile" + n++ + ".enc";
                Encryptor.EncryptFile(encFile, newPath);
                res += newPath + ",";
            }
            Console.WriteLine("sending encFiles str: " + res);
            return res;
        }
        static void initTestCustomer()
        {
			DBCommunicator db = new DBCommunicator();
            DBCommunicator.testDbConnection();
            //Console.WriteLine("Printing database...");
            //DBCommunicator.printDB();

            string toChange = "00000000-0000-0000-3586-123193050990";
            Customer orgCust = DBCommunicator.getCustomer(toChange);
            string newName = "John";
            Console.WriteLine("Before :");
            DBCommunicator.getCustomer(toChange);
            Console.WriteLine("Changing " + toChange + " first name to " + newName);
            bool done = DBCommunicator.update(toChange, DBCommunicator.UpdateType.fName, newName);
            Console.WriteLine("After :");
            DBCommunicator.getCustomer(toChange);

            Console.WriteLine("Before :");
            orgCust = DBCommunicator.getCustomer(toChange);
            Console.WriteLine("Changing " + toChange + " Pin to to " + "1111");
            done = DBCommunicator.update(toChange, DBCommunicator.UpdateType.h_pin, "1111");
            Console.WriteLine("After :");
            orgCust = DBCommunicator.getCustomer(toChange);

            Console.WriteLine("Before :");
            orgCust = DBCommunicator.getCustomer(toChange);
            double nb = 20;
            Console.WriteLine("Changing " + toChange + " balance to to " + nb);
            done = DBCommunicator.update(toChange, DBCommunicator.UpdateType.balance, nb.ToString());
            Console.WriteLine("After :");
            orgCust = DBCommunicator.getCustomer(toChange);

            Console.WriteLine("Before :");
            orgCust = DBCommunicator.getCustomer(toChange);
            string newFingerPath = ""; //put the path to the encrypted file here
            Console.WriteLine("Changing " + toChange + " Finger file path to " + newFingerPath);
            done = DBCommunicator.update(toChange, DBCommunicator.UpdateType.finger_path, newFingerPath);
            Console.WriteLine("After :");

            DBCommunicator.getCustomer(toChange);
            Console.WriteLine("Before :");
            DBCommunicator.getCustomer(toChange);
            string newFacePath = ""; //put the path to the encrypted face files here (comma seperated)
            Console.WriteLine("Changing " + toChange + " Face file path to " + newFacePath);
            done = DBCommunicator.update(toChange, DBCommunicator.UpdateType.face_path, newFacePath);
            Console.WriteLine("After :");
            DBCommunicator.getCustomer(toChange);
        }


        [STAThread]
        static void Main(string[] args) {
			ServerController s = new ServerController();
			// keep file paths to demo files here in comments for backup
			while (true) {
				s.tcp.StartListening();
			}
			
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
