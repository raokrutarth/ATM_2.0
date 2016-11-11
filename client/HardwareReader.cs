using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
	class HardwareReader
	{
		public CameraDataReader cameraReader;
		public FingerPrintDataReader fingerprintReader;
		public TouchScreenDataReader touch;
		public ButtonReader buttonReader;

		public HardwareReader()
		{
			cameraReader = new CameraDataReader();
			fingerprintReader = new FingerPrintDataReader(true);
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
