using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
	class HardwareReader
	{
		/*Methods currently return void for compilation*/
		private int serialPort;
		private CameraDataReader cameraReader;
		private FingerPrintDataReader fingerprintReader;
		private TouchScreenDataReader touch;
		private ButtonReader buttonReader;

		public HardwareReader()
		{
			cameraReader = new CameraDataReader();
			Console.WriteLine("start");
			fingerprintReader = new FingerPrintDataReader(true);
			Console.WriteLine("end");
			touch = new TouchScreenDataReader();
			buttonReader = new ButtonReader();
		}

		public void readData()
		{
			
		}

		public bool validate()
		{
			return false;
		}
	}
}
