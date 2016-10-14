using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmServer
{
    class Authenticator
    {
        public Authenticator()
        {
			ServerController.currentController.RegisterCallback("authPin", authPin);
            /// select hashing algorithim
            /// test encrypt/decrypt
        }

		public bool authPin(Command command)
		{
			return false;
		}
    }
}
