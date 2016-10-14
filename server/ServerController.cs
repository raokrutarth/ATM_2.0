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
		private static TCPCommunicator tcp = new TCPCommunicator();

		//used for callback functions
		private Dictionary<string, TCPDataCallback> callbacks;

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
            Console.WriteLine("In ServerController Main()");
            DBCommunicator dbComm = new DBCommunicator();
			//dbComm.testDb();
			tcp.StartListening();
        }

		public void executeCommand(Command command) {
			bool success = this.callbacks[command.command](command);
			Command c = new Command();


			if (success) {
				//command had a success
				c.command = "success";
				c.data = "";
				c.size = c.command.Length + c.data.Length;
				tcp.Send(tcp.listener, c);
			} else {

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
