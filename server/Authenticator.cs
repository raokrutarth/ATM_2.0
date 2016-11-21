using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

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

		// returns true/ false given:
        // image = new image taken by atm machine
        // db_ImagePath = collection of images the customer provided during account creation 
        public bool verifyFace(string[] db_ImagePath, System.Drawing.Image image)
        {
            // db
            return false;
        }

		public bool authenticatePIN(Command command)
		{
            /*Command c;

			string s = command.dataFinger.ToString();
			Console.WriteLine("*****************Data: {0}", s);
			//authenticate with database

			//return success or failure
            c = new Command("Send", "PIN successfully \nauthenticated");
            ServerController.currentController.tcp.Send(c);
			*/
			return true;
		}

		public bool authenticateFace(Command command) {

			return false;
		}

		public bool authenticateFinger(Command command)
		{
			// Parse bytes as image.
			byte[] image = Encoding.ASCII.GetBytes(command.data);
			ScanAPIDemo.MyBitmapFile myFile = new ScanAPIDemo.MyBitmapFile(320, 480, image);
			FileStream file = new FileStream(".\\finger2.bmp", FileMode.Create);
			file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length);
			file.Close();

			//authenticate with database

			//return success or failure
			Command cmd = new Command("authResponse", "ok/denied");
			ServerController.currentController.tcp.Send(cmd);

			return false;
		}

	}
}
