using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmServer
{
    class DBCommunicator
    {
        enum RequestType { Query, Insert, Peek};
        public DBCommunicator()
        {
            /// Initilize communicator
            /// check connection with database
            /// check validity of  test data
            /// setup encryption
            /// return true on sucess
            /// 
        }
        ~DBCommunicator()
        {
            Console.WriteLine("DBCommunicator object terminated");
        }
    }
}
