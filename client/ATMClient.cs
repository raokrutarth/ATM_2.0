using System;
using System.Windows.Forms;

namespace ATM
{
	public class ATMClient
	{
		// Default connection information.
		//private const string ATM_SERVER_ADDRESS = "atmserver.centralus.cloudapp.azure.com";
		private const string ATM_SERVER_ADDRESS = "192.168.1.230";
		private const int ATM_SERVER_PORT = 11000;

		// Hard-coded values for demonstration.
		public const string USER_ID = "00000000000000000000000000000000";

		public static ATMClient _atmClientObject = null;
		private UserInterface ui;
		private HardwareReader drivers;
		public ServerConnection serverConnection;
		public CurrentUser user;
        
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
			drivers = new HardwareReader();
			ui = new UserInterface();
			user = new CurrentUser(this);
			serverConnection = new ServerConnection(ATM_SERVER_ADDRESS, ATM_SERVER_PORT);

			// Wait for server connection.
			Console.WriteLine("Connecting to server at {0}:{1}.", ATM_SERVER_ADDRESS, ATM_SERVER_PORT);
			while(!serverConnection.Connect())
			{
				Console.WriteLine("Failed to connect to server. Retrying...");
			}

			/* Send initial data, including image sizes.
			System.Drawing.Size imgSize = drivers.fingerprintReader.imageSize;
			string sizeString = imgSize.Width.ToString() + "\n" + imgSize.Height.ToString();
			serverConnection.SendData("setFingerImageSize", sizeString);

			/* // Send fingerprints as a test.
			while (true)
			{
				Console.WriteLine("Place finger 1");
				System.Threading.Thread.Sleep(2000);

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
			} */
        }

        /*
		 * Called once per main loop iteration. This is where program logic is performed.
		 */
        private void iterate()
		{
			Application.Run(new welcomePage(this));
			/*Application.Run(new PinPage(this));
			Application.Run(new PhotoAuth(this));
			Application.Run(new FingerAuthPage(this));
			Application.Run(new MainMenu(this));
			Application.Run(new Confirmation(this));*/
		}

		public static void Main(string[] args)
		{
            ATMClient atm = new ATMClient();

            // Main program loop.
            while (true)
			{
				atm.iterate();
				//System.Threading.Thread.Sleep(5000);
			}

		/*private bool login(string username) {
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
		*/

		/*private void testFace() {
			string filePath = ""; //Put picture file path here
			Message m;

			Bitmap pic = new Bitmap(filePath);
			ImageConverter converter = new ImageConverter();
			byte[] data = (byte[])converter.ConvertTo(pic, typeof(byte[]));

			m = this.serverConnection.SendData("authenticateFace", data, true);
			Console.WriteLine("Response from server: {0}", m.data);
			Console.ReadKey();*/
		}
	}
}
