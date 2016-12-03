using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM {
	public class ATMClient
	{
		public static ATMClient _atmClientObject = null;
		private UserInterface ui;
		private HardwareReader drivers;
		public ServerConnection serverConnection;
		private CurrentUser user; //this will be initialized after someone attempts a login
		
		/*
		 * Creates the ATMClient root class. This is a singleton - only one can exist.
		 */
		public ATMClient()
		{
			if(_atmClientObject == null)
			{
				_atmClientObject = this;
				this.initialize();
			}
			else
			{
				//TODO: Already created. Throw exception?
			}
		}

		~ATMClient()
		{
			if(_atmClientObject == this)
			{
				_atmClientObject = null;
			}
		}

		/*
		 * Initializes the ATMClient application.
		 */
		private void initialize()
		{
			Console.WriteLine("ATM client initializing.");
			drivers = new HardwareReader();
			ui = new UserInterface();
			serverConnection = new ServerConnection("192.168.1.230", 11000);
			while(!serverConnection.Connect())
			{
				Console.WriteLine("Failed to connect to server. Retrying...");
			}

			// Send initial data, including image sizes.
			System.Drawing.Size imgSize = drivers.fingerprintReader.imageSize;
			string sizeString = imgSize.Width.ToString() + "\n" + imgSize.Height.ToString();
			serverConnection.SendData("setFingerImageSize", sizeString);

			// Send fingerprints as a test.
			while (true)
			{
				Console.WriteLine("Place finger 1");
				System.Threading.Thread.Sleep(2000);

				/*fingerprintReader.SaveImage(".\\finger1.bmp", true);
				Console.WriteLine("Place finger 2");
				System.Threading.Thread.Sleep(5000);
				fingerprintReader.SaveImage(".\\finger2.bmp", true);
				Console.WriteLine("Place finger 3");
				System.Threading.Thread.Sleep(5000);
				fingerprintReader.SaveImage(".\\finger3.bmp", true);*/

				// TEST TRANSMIT
				byte[] data;
				while ((data = drivers.fingerprintReader.GetImage()) == null)
				{
					Console.WriteLine("Please put your finger on the scanner.");
					System.Threading.Thread.Sleep(2000);
				}
				Console.WriteLine("Sending data of length {0}", data.Length);
				Message msg = serverConnection.SendData("authenticateFinger", data, true);
				Console.WriteLine("Got response: {0}; {1}; {2}", msg.type, msg.data, msg.size);
			}

			/*int i = 1;
			while (true)
			{
				Message msg = serverConnection.SendData("authenticatePIN", "COUNTING IS FUN! " + i.ToString(), true);
				Console.WriteLine("Got response: {0}; {1}; {2}", msg.type, msg.data, msg.size);
				System.Threading.Thread.Sleep(1000);
			}*/
		}

		/*
		 * Called once per main loop iteration. This is where program logic is performed.
		 */
		private void iterate() {
			string request = "";
			string data = "";
			Message m;

			//TODO: Get request from the user in the GUI

			m = this.serverConnection.SendData(request, data, true);

			//TODO: Print out result on the GUI
		}

		private bool login(string username) {
			//intialize user and server
			Message m;
			string PIN = "";
			bool check = false;
			byte[] data;

			m = serverConnection.SendData("getName", username, true);

			user.setUserName(m.data);

			//Begin Authentication
			//TODO: Get PIN from the GUI
			for (int i = 0; i < 3; i++) {
				m = serverConnection.SendData("authenticatePIN", PIN, true);
				if (m.data.Equals("PIN Verified")) {
					check = true;
					break;
				}
			}
			//Verify that the PIN entered was correct and max attempts was not exceeded
			if (!check) {
				//TODO:Return the GUI to the first page
				return false;
			}
			check = false;

			//Check if biometric auth is required
			m = serverConnection.SendData("authRequired", "", true);

			//Biometric auth required
			if (m.data.Equals("Yes")) {
				for (int i = 0; i < 3; i++) {
					//TODO: Grab fingerprint image and send for auth from GUI
					data = Encoding.ASCII.GetBytes("JunkForNow");
					m = serverConnection.SendData("authenticateFinger", data, true);
					if (m.data.Equals("Fingerprint Verified")) {
						check = true;
						break;
					}
				}
				
				//Verify that fingerprint matched and max number of attempts not exceeded
				if (!check) {
					//TODO: Print max attempts exceeded and return to first page in GUI
					return false;
				}
				check = false;
				
				for(int i = 0; i < 3; i++) {
					//TODO: Grab picture from GUI
					data = Encoding.ASCII.GetBytes("JunkForNow");
					m = serverConnection.SendData("authenticateFace", data, true);
					if (m.data.Equals("Face Verified"))
					{
						check = true;
						break;
					}
				}

				//Verify that face matched and max number of attempts not exceeded
				if (!check)
				{
					//TODO: Print max attempts exceeded and return to first page in GUI
					return false;
				}

				this.user.setLoggedIn(true);
				return true;

			//Biometric auth not required
			} else {
				this.user.setLoggedIn(true);
				return true;
			}
		}

		public static void Main(string[] args) {
			ATMClient atm = new ATMClient();
			string accountNumber = "";

			//TODO: Grab the account number from the user in the GUI

			atm.login(accountNumber);
			// Main program loop.
			while (atm.user.getLoggedIn()) {
				atm.iterate();
				System.Threading.Thread.Sleep(5000);
			}
		}
	}
}
