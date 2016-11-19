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
			serverConnection = new ServerConnection("192.168.1.10", 11000);
			while(!serverConnection.Connect())
			{
				Console.WriteLine("Failed to connect to server. Retrying...");
			}


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
			while((data = drivers.fingerprintReader.GetImage()) == null)
			{
				Console.WriteLine("Please put your finger on the scanner.");
				System.Threading.Thread.Sleep(2000);
			}
			Console.WriteLine("Sending data of length {0}", data.Length);
			Message msg = serverConnection.SendData("authenticateFinger", data, true);
			Console.WriteLine("Got response: {0}; {1}; {2}", msg.type, msg.data, msg.size);

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
		private void iterate()
		{
			//Message result = serverConnection.SendData("authenticatePIN", "this is some test data\n1 2 3<EOF>", true);
			//Console.WriteLine("Got type \"{0}\" and message \"{1}\".", result.type, result.data);
		}

		private bool login(string username)
		{
			//check for username and PIN
/*			if (true) {

			}

			//check for fingerprint match
			if (true) {

			}

			//check for facial recognition
			if (true) {

			}
*/
			return false;
		}

		public static void Main(string[] args)
		{
			ATMClient atm = new ATMClient();

			// Main program loop.
			while (true)
			{
				atm.iterate();
				System.Threading.Thread.Sleep(5000);
			}
		}
	}
}
