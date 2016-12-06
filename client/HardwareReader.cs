using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
	public class HardwareReader
	{
		public CameraDataReader cameraReader;
		public FingerPrintDataReader fingerprintReader;

		public HardwareReader()
		{
			cameraReader = new CameraDataReader();
			//fingerprintReader = new FingerPrintDataReader(true);
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
