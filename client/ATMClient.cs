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

        }

		/*Private methods*/
		private bool login(string username) {
			//check for username and PIN
			if (true) {

			}

			//check for fingerprint match
			if (true) {

			}

			//check for facial recognition
			if (true) {

			}

			return false;
		}
	}
}
