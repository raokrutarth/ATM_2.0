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
			ServerController.currentController.RegisterCallback("authenticatePIN", authenticatePIN);
			ServerController.currentController.RegisterCallback("authenticateFace", authenticateFace);
			ServerController.currentController.RegisterCallback("authenticateFinger", authenticateFinger);
			/// select hashing algorithim
			/// test encrypt/decrypt
		}

		public bool authenticatePIN(Command command)
		{
			

			return true;
		}

		public bool authenticateFace(Command command) {

			return false;
		}

		public bool authenticateFinger(Command command) {

			return false;
		}

	}
}
