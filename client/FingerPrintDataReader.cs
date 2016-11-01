/*
 * FingerPrintDataReader
 * Takes in data from the fingerprint scanner.
 */

using System;
using ScanAPIHelper;

namespace ATM
{
	class FingerPrintDataReader
	{
		bool connected;
		int interfaceNumber;

		/*
		 * Creates an interface to the fingerprint reader.
		 * \param waitForDevice If true, will block until the device is connected.
		 */
		public FingerPrintDataReader(bool waitForDevice)
		{
			connected = false;
			interfaceNumber = Device.BaseInterface;
			try
			{
				FTRSCAN_INTERFACE_STATUS[] status = Device.GetInterfaces();
				while (true)
				{
					if (status[interfaceNumber] == FTRSCAN_INTERFACE_STATUS.FTRSCAN_INTERFACE_STATUS_CONNECTED)
					{
						Console.WriteLine("Fingerprint reader connected.");
						connected = true;
					}
					if(!waitForDevice)
					{
						break;
					}
					System.Threading.Thread.Sleep(1000);
				}
			}
			catch (ScanAPIException ex)
			{
				Console.WriteLine("ERROR: Fingerprint reader initialization: {0}", ex.ToString());
			}
			finally
			{
				if(!connected)
				{
					Console.WriteLine("Fingerprint reader connection failed.");
				}
			}
		}
	}
}
