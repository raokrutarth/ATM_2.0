using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
	class HardwareReader
	{
		private CameraDataReader cameraReader;
		private FingerPrintDataReader fingerprintReader;
		private TouchScreenDataReader touch;
		private ButtonReader buttonReader;

		public HardwareReader()
		{
			cameraReader = new CameraDataReader();
			fingerprintReader = new FingerPrintDataReader(true);
			Console.WriteLine("Place finger 1");
			System.Threading.Thread.Sleep(5000);
			fingerprintReader.SaveImage(".\\finger1.bmp", true);
			Console.WriteLine("Place finger 2");
			System.Threading.Thread.Sleep(5000);
			fingerprintReader.SaveImage(".\\finger2.bmp", true);
			Console.WriteLine("Place finger 3");
			System.Threading.Thread.Sleep(5000);
			fingerprintReader.SaveImage(".\\finger3.bmp", true);
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
