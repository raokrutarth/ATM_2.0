using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmServer
{
    public class Customer
    {
        //("@CustomerID", SqlDbType.UniqueIdentifier).Value = new Guid(CustID.PadLeft(32, '0'));
        //            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
        //            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
        //            cmd.Parameters.Add("@HPIN", SqlDbType.NVarChar).Value = hPin;
        //            cmd.Parameters.Add("@HFinger", SqlDbType.NVarChar).Value = hFinger;
        //            cmd.Parameters.Add("@HFace", SqlDbType.NVarChar).Value = hFace;
        //            cmd.Parameters.Add("@Balance", SqlDbType.Money).Value = balance;
        public Guid CustomerID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String HPIN { get; set; }
        public String finger_path { get; set; }
        public String face_path { get; set; }
        public double balance { get; set; }
		public bool biometricRequired { get; set; }

		public Customer() {
			ServerController.currentController.registerCustomerCallback("getAccountBalance", getAccountBalance);
			ServerController.currentController.registerCustomerCallback("makeWithdrawal", makeWithdrawal);
			ServerController.currentController.registerCustomerCallback("makeDeposit", makeDeposit);
			ServerController.currentController.registerCustomerCallback("changePIN", changePIN);
		}

		//returns the balance for the requested account
		public string getAccountBalance(ClientData clientData, string accountName) {
			string successReturn = accountName + ": ";
			string accountBalance = "";

			//get account balance from database
			Customer c = clientData.getCust();
			accountBalance = c.balance.ToString();

			//success return
			successReturn += accountBalance;
			return successReturn;

			//failure return
			//return "Balance Error";
		}

		//Reduces the Client's balance by sizeOfWithdrawal
		public string makeWithdrawal(ClientData clientData, string sizeOfWithdrawal) {
			double w = Convert.ToDouble(sizeOfWithdrawal);

			this.balance = this.balance - w;

            //TODO: Update the database balance
            bool done = DBCommunicator.update(CustomerID.ToString(), DBCommunicator.UpdateType.balance, this.balance.ToString());

			if (done) {
				//success return
				return sizeOfWithdrawal + " withdrawn";

			} else {
				//failure return
				return "Withdrawal Error";
			}
			
		}

		//Adds the Clients balance by sizeOfDeposit
		public string makeDeposit(ClientData clientData, string sizeOfDeposit)	{
			double d = Convert.ToDouble(sizeOfDeposit);

			this.balance = this.balance + d;

            bool done = DBCommunicator.update(CustomerID.ToString(), DBCommunicator.UpdateType.balance, this.balance.ToString() );            

			if (done) {
				//success return
				return sizeOfDeposit + " deposited";

			} else {
				//failure return
				return "Deposit Error";
			}
		}

		//Changes the old PIN for the Client to newPIN
		public string changePIN(ClientData clientData, string newPIN) {
			this.HPIN = newPIN;

            bool done = DBCommunicator.update(CustomerID.ToString(), DBCommunicator.UpdateType.h_pin, this.HPIN);

			if (done) {
				//success return
				return "PIN Succesfully changed";

			} else {
				//failure return
				return "Error PIN not changed";
			}

		}

	}
	
}
