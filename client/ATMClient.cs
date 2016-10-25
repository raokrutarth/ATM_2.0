using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM {
    public class ATMClient {
		private UserInterface ui = new UserInterface();
		private HardwareReader drivers = new HardwareReader();
		private CurrentUser user; //this will be initialized after someone attempts a login

		/*Public methods*/
		public static void Main(string[] args) {
            Console.WriteLine("ATM client initializing.");
            ServerConnection connection = new ServerConnection("192.168.1.230", 11000);
            connection.Connect();

			// Main program loop.
			while (true)
			{
				Message result = connection.SendData("authenticatePIN", "this is some test data\n1 2 3<EOF>", true);
				Console.WriteLine("Got type \"{0}\" and message \"{1}\".", result.type, result.data);
				System.Threading.Thread.Sleep(5000);
			}
        }

		/*Private methods*/
		private bool login(string username) {
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
	}
}
