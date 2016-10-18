using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM {
	class HardwareReader {
		/*Methods currently return void for compilation*/
		private int serialPort;
		private CameraDataReader cam = new CameraDataReader();
		private FingerPrintDataReader fin = new FingerPrintDataReader();
		private TouchScreenDataReader touch = new TouchScreenDataReader();
		private ButtonReader button = new ButtonReader();

		public void readData() {
			
		}

		public bool validate() {
			return false;
		}
	}
}
