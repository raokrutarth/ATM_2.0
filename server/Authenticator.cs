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
		const double MIN_FINGERPRINT_SIMILARITY = 0.05;

        public Authenticator()
        {
			// Register TCP callbacks.
			ServerController.currentController.RegisterCallback("authenticateAccount", getName);
			ServerController.currentController.RegisterCallback("authenticatePIN", authenticatePIN);
			ServerController.currentController.RegisterCallback("authenticateFace", authenticateFace);
			ServerController.currentController.RegisterCallback("authenticateFinger", authenticateFinger);
			ServerController.currentController.RegisterCallback("setFingerImageSize", setFingerImageSize);
		}

        // returns true/ false given:
        // newImagePath = path to new image taken by atm machine
        // currentCust = Customer object that holds the paths to the encrypted files. 
        public async System.Threading.Tasks.Task<bool> verifyFace(Customer currentCust, string newImagePath)
        {
            string encBases = currentCust.face_path;
            string[] basePaths = encBases.Split(',');

            List<string> bp = new List<string>();
            foreach (string path in basePaths)
                bp.Add(path);
            return await FaceIdentification.verifyFace(newImagePath, bp, currentCust.CustomerID.ToString());
        }

        /*
		 * Validates and stores the user's account number.
		 */
        public bool getName(ClientData clientData, Command command)
		{
			// Parse account number.
			int accountNumber = Int32.Parse(command.data);
			// Validate and store account number.
			//TODO: validate account number here.
			clientData.accountNumber = accountNumber;
            // set global customer using clientData.setCust()
			// Send response.
			Command cmd = new Command("authResponse", "ok");
			ServerController.currentController.tcp.Send(cmd);
			return true;
		}

		/*
		 * Validate PIN sent from client and send response.
		 */
		public bool authenticatePIN(ClientData clientData, Command command)
		{
			// Parse PIN.
			int pin = Int32.Parse(command.data);

			// Validate PIN.
			//TODO: 
            // compare clientData.custObj.pin == newPin


            // 

			// Send response.
			Command cmd = new Command("authResponse", "ok");
			ServerController.currentController.tcp.Send(cmd);

			return true;
		}

		/*
		 * Verify face image sent from client and send response.
		 */
		public bool authenticateFace(ClientData clientData, Command command)
		{
			// Parse bytes as image.
			byte[] data = Encoding.ASCII.GetBytes(command.data);
			ScanAPIDemo.MyBitmapFile bmp = new ScanAPIDemo.MyBitmapFile(320, 480, data);
			Stream fStream = new MemoryStream(bmp.BitmatFileData);
			Bitmap image1 = new Bitmap(fStream);
            string savedPath = "./<cust-ID>_newFace.png";
            // save this image to a file like <cust-ID>_newFace.png

            //bool faceResult =  this.verifyFace(<customer object>, savedPath_newfile );

            // Send response.
            Command cmd = new Command("authResponse", "ok");
			ServerController.currentController.tcp.Send(cmd);

			return true;
		}

		/*
		 * Verify fingerprint image sent from client and send response.
		 */
		public bool authenticateFinger(ClientData clientData, Command command)
		{
			// Parse bytes as image.
			byte[] data = Encoding.ASCII.GetBytes(command.data);
			ScanAPIDemo.MyBitmapFile bmp = new ScanAPIDemo.MyBitmapFile(clientData.fingerprintImageSize.Width,
				clientData.fingerprintImageSize.Height, data);
			Stream fStream = new MemoryStream(bmp.BitmatFileData);
			Bitmap image1 = new Bitmap(fStream); // new img
            // fetch enc file path
            // decrypt

			Bitmap image2 = new Bitmap(".\\test-img.bmp"); //replace this file path with the path from the database
            // db image
			//image1.Save(".\\img.bmp");

			// Extract features from images.
			var featureExtractor = new MTripletsExtractor() {MtiaExtractor = new Ratha1995MinutiaeExtractor() };
			var features1 = featureExtractor.ExtractFeatures(image1);
			var features2 = featureExtractor.ExtractFeatures(image2);



			// Perform matching.
			var matcher = new M3gl();
			double similarity = matcher.Match(features1, features2);
			Console.WriteLine("Fingerprint similarity of {0}", similarity);

            // delete decrypted file from db

			// Return success or failure.
			if(similarity >= MIN_FINGERPRINT_SIMILARITY)
			{
				clientData.authFinger = true;
				Command cmd = new Command("authResponse", "ok");
				ServerController.currentController.tcp.Send(cmd);
				return true;
			}
			else
			{
				clientData.authFinger = false;
				Command cmd = new Command("authResponse", "denied");
				ServerController.currentController.tcp.Send(cmd);
				return false;
			}
		}

		/*
		 * Sets the expected size of received fingerprint images.
		 */
		public bool setFingerImageSize(ClientData clientData, Command command)
		{
			string[] lines = command.data.Split('\n');
			clientData.fingerprintImageSize.Width = Int32.Parse(lines[0]);
			clientData.fingerprintImageSize.Height = Int32.Parse(lines[1]);
			Console.WriteLine("Client is using fingerprint image size of {0}", clientData.fingerprintImageSize.ToString());
			return true;
		}
	}
}
