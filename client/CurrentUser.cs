using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM {
	public class CurrentUser {
		private string userName;
		private bool loggedIn;

		public void setUserName(string name) {
			this.userName = name;
		}

		public void setLoggedIn(bool value) {
			this.loggedIn = value;
		}

		public bool getLoggedIn() {
			return this.loggedIn;
		}

		public string getUserName() {
			return this.userName;
		}
	}
}
