using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
	public class CurrentUser
	{
		private ATMClient atm;
		private string userName;
		private bool loggedIn;

        public CurrentUser(ATMClient atm)
        {
			this.atm = atm;
            userName = null;
            loggedIn = false;
        }

        public CurrentUser(ATMClient atm, string name)
        {
			this.atm = atm;
            userName = name;
            loggedIn = false;
        }

        public void login()
        {
            loggedIn = true;
        }

        public void logout()
        {
            loggedIn = false;
        }

        public String getName()
        {
            if (userName == null)
            {
                return "null";
            }
            return userName;
        }

        public void setName(String name)
        {
            userName = name;
        }
	}
}
