using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using PatternRecognition.FingerprintRecognition.Core;
using PatternRecognition.FingerprintRecognition.FeatureExtractors;
using PatternRecognition.FingerprintRecognition.Matchers;

namespace AtmServer
{
    class Authenticator
    {
		const double MIN_FINGERPRINT_SIMILARITY = 30.0;

        public Authenticator()
        {
			ServerController.currentController.RegisterCallback("authenticatePIN", authenticatePIN);
			ServerController.currentController.RegisterCallback("authenticateFace", authenticateFace);
			ServerController.currentController.RegisterCallback("authenticateFinger", authenticateFinger);
			/// select hashing algorithim
			/// test encrypt/decrypt
		}

		// returns true/ false given:
        // image = new image taken by atm machine
        // db_ImagePath = collection of images the customer provided during account creation 
        public bool verifyFace(string[] db_ImagePath, System.Drawing.Image image)
        {
            // db
            return false;
        }

		public bool authenticatePIN(Command command)
		{
            /*Command c;

			string s = command.dataFinger.ToString();
			Console.WriteLine("*****************Data: {0}", s);
			//authenticate with database

			//return success or failure
            c = new Command("Send", "PIN successfully \nauthenticated");
            ServerController.currentController.tcp.Send(c);
			*/
			return true;
		}

		public bool authenticateFace(Command command) {

			return false;
		}

		public bool authenticateFinger(Command command)
		{
			// Parse bytes as image.
			byte[] data = Encoding.ASCII.GetBytes(command.data);

			ScanAPIDemo.MyBitmapFile bmp = new ScanAPIDemo.MyBitmapFile(320, 480, data);
			Stream fStream = new MemoryStream(bmp.BitmatFileData);
			Bitmap image1 = new Bitmap(fStream);
			Bitmap image2 = new Bitmap(".\\test-img.bmp");

			// Extract features from images.
			var featureExtractor = new DalaunayMTpsExtractor() {MtiaExtractor = new Ratha1995MinutiaeExtractor() };
			var features1 = featureExtractor.ExtractFeatures(image1);
			var features2 = featureExtractor.ExtractFeatures(image2);

			// Perform matching.
			var matcher = new MPN();
			double similarity = matcher.Match(features1, features2);
			Console.WriteLine("Fingerprint similarity of {0}", similarity);

			// Return success or failure.
			if(similarity >= MIN_FINGERPRINT_SIMILARITY)
			{
				Command cmd = new Command("authResponse", "ok");
				ServerController.currentController.tcp.Send(cmd);
				return true;
			}
			else
			{
				Command cmd = new Command("authResponse", "denied");
				ServerController.currentController.tcp.Send(cmd);
				return false;
			}
		}

	}
}
