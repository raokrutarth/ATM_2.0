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


		static void Main(string[] args) {

        }
	}
}
