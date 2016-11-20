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
        [STAThread]
        static void Main(string[] args)
        {
            int width = 200, height = 30;
            Console.SetWindowSize(width, height);
            Console.WriteLine("In ServerController Main()");
            DBCommunicator dbComm = new DBCommunicator();
            //dbComm.FillDB();
            //Console.WriteLine("Printing database...");
            //dbComm.printDB();
            
            string toChange = "00000000-0000-0000-3586-123193050990";
            string newName = "Peter";
            Console.WriteLine("Before :");
            dbComm.getCustomer(toChange);
            Console.WriteLine("Changing " + toChange + " first name to " + newName);
            bool done = dbComm.update(toChange, DBCommunicator.UpdateType.fName, newName);
            //Console.WriteLine("Printing database...");
            Console.WriteLine("After :");
            dbComm.getCustomer(toChange);

            /*FaceIdentification fi = new FaceIdentification("<new Image Path>", "<custID>");
            while (true)
            {
                FaceIdentification.testRun();
            }*/
            Console.ReadKey();

        }
    }
}
