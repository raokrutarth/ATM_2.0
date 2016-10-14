using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtmServer
{
    class ServerController
    {
		//used for callback functions
		private Dictionary<string, TCPCallback> callbacks;

		private string accountNumber = string.Empty;

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
        void recoverSession()
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("In ServerController Main()");
            DBCommunicator dbComm = new DBCommunicator();
			//dbComm.testDb();
			TCPCommunicator tcp = new TCPCommunicator();
			setup();
			tcp.StartListening();
        }

		public void executeCommand(Command command) {
			if (command.command.Equals("login")) {

			} else if (command.command.Equals("authenticatePIN")) {

			} else if (command.command.Equals("authenticateFace")) {

			} else if (command.command.Equals("authenticateFinger")) {

			} //else if (command.command.Equals("login")) {

			//}
			//command match not found return error to the client
			else {
				//TODO: call the callback function
				
			}
		}

		//registers callback functions
		public bool RegisterCallback(string dataType, TCPCallback callback) {
			this.callbacks[dataType] = callback;
			return true;
		}

		public static void setup() {

		}
    }
}
