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
			TCPCommunicator.StartListening();
        }
    }
}
