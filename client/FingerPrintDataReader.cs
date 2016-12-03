/*
 * FingerPrintDataReader
 * Takes in data from the fingerprint scanner.
 */

using System;
using System.Drawing;
using System.IO;
using ScanAPIHelper;

namespace ATM
{
	class FingerPrintDataReader
	{
		private bool connected;
		private int interfaceNumber;
		private Device scanner;
		private byte[] image;
		public Size imageSize {  get; private set; }

		/*
		 * Creates an interface to the fingerprint reader.
		 * \param waitForDevice If true, will block until the device is connected.
		 */
		public FingerPrintDataReader(bool waitForDevice)
		{
			// Set defaults
			this.image = null;
			this.scanner = null;
			this.connected = false;
			interfaceNumber = Device.BaseInterface;
			bool notifiedWait = false;

			try
			{
				// Check that the device is connected.
				while (!this.connected)
				{
					FTRSCAN_INTERFACE_STATUS[] status = Device.GetInterfaces();
					if (status[interfaceNumber] == FTRSCAN_INTERFACE_STATUS.FTRSCAN_INTERFACE_STATUS_CONNECTED)
					{
						this.connected = true;
						break;
					}
					else if(!waitForDevice)
					{
						break;
					}
					if(!notifiedWait)
					{
						notifiedWait = true;
						Console.WriteLine("Waiting for fingerprint scanner.");
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
				if(this.connected)
				{
					Console.WriteLine("Fingerprint reader connected.");
				}
				else
				{
					Console.WriteLine("Fingerprint reader connection failed.");
				}
			}

			// Open the connection.
			this.OpenDevice();
		}

		/*
		 * Opens a connection to the device.
		 */
		private void OpenDevice()
		{
			try
			{
				this.scanner = new Device();
				this.scanner.Open(this.interfaceNumber);
				this.imageSize = this.scanner.ImageSize;
				Console.WriteLine("Scanner uses images of size {0}", this.imageSize.ToString());
			}
			catch (ScanAPIException ex)
			{
				this.CloseDevice();
				Console.WriteLine("Scanner open error: {0}", ex.ToString());
			}
		}

		private void CloseDevice()
		{
			if(this.scanner != null)
			{
				this.scanner.Dispose();
				this.scanner = null;
				Console.WriteLine("Closed scanner");
			}
		}

		public byte[] GetImage()
		{
			try
			{
				this.image = this.scanner.GetFrame();
				return this.image;
			}
			catch (ScanAPIException ex)
			{
			}
			return null;
		}

		public void SaveImage(string path, bool getImage)
		{
			if(getImage)
			{
				this.GetImage();
			}
			ScanAPIDemo.MyBitmapFile myFile = new ScanAPIDemo.MyBitmapFile(this.imageSize.Width, this.imageSize.Height, this.image);
			FileStream file = new FileStream(path, FileMode.Create);
			file.Write(myFile.BitmatFileData, 0, myFile.BitmatFileData.Length);
			file.Close();
		}
	}
}
