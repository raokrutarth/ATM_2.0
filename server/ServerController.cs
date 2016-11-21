using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtmServer
{
	public delegate bool TCPDataCallback(ClientData clientData, Command command);

	class ServerController
    {
		public static ServerController currentController;

		// Member fields.
		Dictionary<string, TCPDataCallback> callbacks;
		public DBCommunicator database;
		public Authenticator auth;
		public TCPCommunicator tcp;

		private string accountNumber = string.Empty;

		public ServerController()
        {
			currentController = this;
			this.callbacks = new Dictionary<string, TCPDataCallback>();
			this.database = new DBCommunicator();
			this.auth = new Authenticator();
			this.tcp = new TCPCommunicator();
		}

        void serveClient()
        {
            /// identify client ID
            /// assign new TCP communicator object
            /// assign new DBcomm object
            /// terminate connection when needed
        }

        void recoverSession()
        {

        }

        [STAThread]
        static void Main(string[] args)
        {
            /*int width = 220, height = 50;
            Console.SetWindowSize(width, height);
            Console.WriteLine("In ServerController Main()");
            DBCommunicator dbComm = new DBCommunicator();
            dbComm.FillDB();
            Console.WriteLine("Finished FillDB()\nCalling readDB()");
            dbComm.printDB();

            FaceIdentification fi = new FaceIdentification("<new Image Path>", "<custID>");
            while (true)
            {
                FaceIdentification.testRun();
            }*/

            //Console.WriteLine("In ServerController Main()");
			ServerController controller = new ServerController();
			controller.tcp.StartListening();
        }

		public void executeCommand(ClientData clientData, Command command) {
			// Call our callback here.
			if (this.callbacks.ContainsKey(command.command)) {
				Console.WriteLine("Calling the callback: {0}", command.command);
				bool success = this.callbacks[command.command](clientData, command);
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

		public void setup() {
			
		}
	}
}
