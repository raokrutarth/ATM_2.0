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
            int width = 200, height = 50;
            Console.SetWindowSize(width, height);
            Console.WriteLine("In ServerController Main()");
            DBCommunicator dbComm = new DBCommunicator();
            dbComm.FillDB();
            
        }
    }
}
