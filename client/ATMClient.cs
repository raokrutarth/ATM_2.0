using System;
using System.Windows.Forms;

namespace ATM
{
	public class ATMClient
	{
		// Default connection information.
		private const string ATM_SERVER_ADDRESS = "atmserver.centralus.cloudapp.azure.com";
		private const int ATM_SERVER_PORT = 11000;

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
			user = new CurrentUser();
			serverConnection = new ServerConnection(ATM_SERVER_ADDRESS, ATM_SERVER_PORT);

			// Wait for server connection.
			Console.WriteLine("Connecting to server at {0}:{1}.", ATM_SERVER_ADDRESS, ATM_SERVER_PORT);
			while(!serverConnection.Connect())
			{
				Console.WriteLine("Failed to connect to server. Retrying...");
			}

			// Send initial data, including image sizes.
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
			Application.Run(new PinPage(this));
			Application.Run(new PhotoAuth(this));
			Application.Run(new FingerAuthPage(this));
			Application.Run(new MainMenu(this));
			Application.Run(new Confirmation(this));
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
		}
	}
}
