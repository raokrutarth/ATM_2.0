﻿using System;
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
			// ServerController.currentController.RegisterCallback("authenticateFace", authenticateFace);
			ServerController.currentController.RegisterCallback("authenticateFinger", authenticateFinger);
			ServerController.currentController.RegisterCallback("setFingerImageSize", setFingerImageSize);
		}
        /*
		 * Validates and stores the user's account number.
		 */
        public bool getName(ClientData clientData, Command command)
		{
			// Parse account number.
			Guid accountNumber = new Guid(command.data.PadLeft(32, '0'));
            // Validate and store account number.
            Customer currCust = DBCommunicator.getCustomer(accountNumber.ToString());
            clientData.setCust(currCust);			
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
			// Validate PIN.
            // compare clientData.custObj.pin == newPin
            string db_pin = clientData.getCust().HPIN;

			// Send response.
            if(db_pin.Equals(command.data))
            {
                Command cmd = new Command("authResponse", "ok");
                ServerController.currentController.tcp.Send(cmd);
            }
            else
            {
                // invalid pin
                return false;
            }
			return true;
		}

        // returns true/ false given:
        // newImagePath = path to new image taken by atm machine
        // currentCust = Customer object that holds the paths to the encrypted files. 
        public async System.Threading.Tasks.Task<bool> verifyFace(Customer currentCust, string newImagePath)
        {
            string encBases = currentCust.face_path;
            string[] basePaths = encBases.Split(',');
            string DecryptedFilePath;
            string currentDir = Directory.GetCurrentDirectory();
            List <string> bp = new List<string>();
            int n = 0;
            // db stores paths to encrypted files
            // decrypt each file and send all base file to verifyFace()
            foreach (string path in basePaths)
            {
                DecryptedFilePath = currentDir + "\\" + currentCust.CustomerID.ToString().Trim('-') + "_Baseface" + n++ + ".bmp";
                Encryptor.DecryptFile(path, DecryptedFilePath);
                bp.Add(DecryptedFilePath);
            }                
            return await FaceIdentification.verifyFace(newImagePath, bp, currentCust.CustomerID.ToString());
        }
        /*
		 * Verify face image sent from client and send response.
		 */
        public async System.Threading.Tasks.Task<bool> authenticateFace(ClientData clientData, Command command)
        {
            // Parse bytes as image.
            byte[] data = Encoding.ASCII.GetBytes(command.data);
            ScanAPIDemo.MyBitmapFile bmp = new ScanAPIDemo.MyBitmapFile(320, 480, data);
            Stream fStream = new MemoryStream(bmp.BitmatFileData);
            Bitmap fromAtm = new Bitmap(fStream);
            string currentDir = Directory.GetCurrentDirectory();
            Customer currCust = clientData.getCust();
            string faceFileDest = currentDir + "\\" + currCust.CustomerID.ToString().Trim('-') + "_NewFace.bmp";
            try
            {
                if (fromAtm != null)
                {
                    fromAtm.Save(faceFileDest);
                    Console.WriteLine("New face saved to " + faceFileDest);
                }
                else
                {
                    Console.WriteLine("Empty face image recieved in Authenticator");
                    return false;
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving recieved face file");
                Console.WriteLine(e.Message);
                return false;
            }
            bool faceResult = await verifyFace(currCust, faceFileDest);
            // delete all un encrypted files here
            if(faceResult)
            {
                // Send response.
                Command cmd = new Command("authResponse", "ok");
                ServerController.currentController.tcp.Send(cmd);
                return true;
            }
            else
            {
                // face verification failed
                // send a response to the client
                return false;
            }
            
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
