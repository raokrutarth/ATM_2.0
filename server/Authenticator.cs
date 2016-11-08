using System;
using System.Collections.Generic;
using System.IO;
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
            Command c; 

			//authenticate with database

			//return success or failure
            c = new Command("Send", "PIN successfully authenticated");
            ServerController.currentController.callbacks[c.command](command);

			return true;
		}

		public bool authenticateFace(Command command) {

			return false;
		}

		public bool authenticateFinger(Command command) {
			Command c;
			byte[] image = Encoding.ASCII.GetBytes(command.data);

			ScanAPIDemo.MyBitmapFile myFile = new ScanAPIDemo.MyBitmapFile(320, 480, image);
			FileStream file = new FileStream(path, FileMode.Create);
			file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length);
			file.Close();

			//authenticate with database

			//return success or failure
			c = new Command("Send", "Fingerprint successfully authenticated");
			ServerController.currentController.callbacks[c.command](command);

			return false;
		}

	}
}
