using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM {

	public class UserInterface {
		//various buttons for the User Interface
		private ButtonCtrl viewBalance;
		private ButtonCtrl withdraw;
		private ButtonCtrl deposit;
		private ButtonCtrl accountSettings;
		private ButtonCtrl changeLanguage;
		private ButtonCtrl changePin;

		//constructor
		public UserInterface() {
			this.viewBalance = new ButtonCtrl();
			this.withdraw = new ButtonCtrl();
			this.deposit = new ButtonCtrl();
			this.accountSettings = new ButtonCtrl();
			this.changeLanguage = new ButtonCtrl();
			this.changePin = new ButtonCtrl();
		}

		//public methods

		//private methods
    }
}