using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtmServer
{
	public delegate bool TCPDataCallback(Command command);

	class ServerController
    {
		public static ServerController currentController;
		//private static TCPCommunicator tcp = new TCPCommunicator();

		//used for callback functions
		public Dictionary<string, TCPDataCallback> callbacks = new Dictionary<string, TCPDataCallback>();

		private string accountNumber = string.Empty;

		public ServerController()
        {
			currentController = this;
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
        static void Main(string[] args)
        {
            //Console.WriteLine("In ServerController Main()");
			ServerController controller = new ServerController();
            DBCommunicator dbComm = new DBCommunicator();
			Authenticator testAuth = new Authenticator();
			//Console.WriteLine("Callbacks: {0}", controller.callbacks.ToString());
			//dbComm.testDb();
			TCPCommunicator tcp = new TCPCommunicator();
			tcp.StartListening();
        }

		public void executeCommand(Command command) {
			// Call our callback here.
			Console.WriteLine("Keys:");
			foreach (KeyValuePair<string, TCPDataCallback> kvp in this.callbacks) {
				Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
			}

			if (this.callbacks.ContainsKey(command.command)) {
				Console.WriteLine("Calling the callback: {0}", command.command);
				bool success = this.callbacks[command.command](command);
			} else {
				Console.WriteLine("ERROR: Invalid message name received.");
				Console.WriteLine("Name: {0} {1}", command.command, command.command.Length);
			}
		}

		//registers callback functions
		public bool RegisterCallback(string dataType, TCPDataCallback callback) {
			//Console.WriteLine("Registered callback for {0}: {1}", dataType, callback.ToString());
			this.callbacks[dataType] = callback;
			return true;
		}

		public void setup() {
			
		}
	}
}
