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
		private ServerConnection serverConnection;
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
			//serverConnection.Connect();
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
/*			if () {

			}

			//check for fingerprint match
			if () {

			}

			//check for facial recognition
			if () {

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
