﻿using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtmServer
{
    class FaceIdentification
    {
        //Group Information 
        static string groupId = "atm20_customers";
        static string groupName = "test_customers";

        //FaceService Client object initilized with subscription key
        static FaceServiceClient face_api = new FaceServiceClient("38e4c823cbc344a2b882c5b3ada6dbcd");



        public FaceIdentification(string imagePath, string clientID)
        {
           // init group and get customer info or files to cross check with           
        }

        
        public static async void testRun()
        {
            try
            {
                Console.WriteLine("1: Training (will train a new person group and create a person for each folder");
                Console.WriteLine("2: Query (select image and verify against group created in (1) ");

                var choice = Console.ReadKey();

                if (choice.KeyChar == '1')
                {

                    Console.WriteLine();
                    Console.WriteLine("Initilizing group");
                    System.IO.DirectoryInfo diRoot = new System.IO.DirectoryInfo(System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Images"));

                    //Creating group
                    var group = await createGroup(groupId, groupName); //**********************

                    foreach (var folder in diRoot.GetDirectories() )
                    {
                        //Getting all training images
                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(folder.FullName);
                        List<string> imageFiles = new List<string>();
                        di.GetFiles().ToList().ForEach(f => imageFiles.Add(f.FullName));

                        //Add person to group and related images. Person name = name of folder where files are located
                        addPersonToGroup(groupId, folder.Name, imageFiles); // ******************

                        Console.WriteLine("Added " + folder.Name + " to group" );

                        //Used to prevent demo license threshold
                        System.Threading.Thread.Sleep(20000);
                    }
                    //Train group
                    trainPersonGroup(groupId);  //********************
                }
                else //person image to be identified
                {              
                    
                    Console.WriteLine("Select image");

                    OpenFileDialog fd = new OpenFileDialog();
                    fd.ShowDialog();
                    string fotoPath = fd.FileName;
                    // string fotoPath = Console.ReadLine();


                    fotoPath = fotoPath.Replace("\"", string.Empty);
                    //Identify person 
                    var verifiedPersons = identifyPersons(groupId, fotoPath);   // **************************
                    //Get Person information
                    foreach (var VerifiedPerson in verifiedPersons.Result)
                    {
                        if (VerifiedPerson.Candidates.Length > 0)
                        {
                            Console.WriteLine("Person detected");
                            var person = getPersonById(groupId, VerifiedPerson.Candidates[0].PersonId);  // *****************
                            person.Wait();
                            Console.WriteLine("Name: " + person.Result.Name + " faceID.len: " +
                                person.Result.PersistedFaceIds.Length + "  personID:" + VerifiedPerson.Candidates[0].PersonId.ToString() +
                                    " DetectionConfidence: " + VerifiedPerson.Candidates[0].Confidence);
                        }
                        else
                        {
                            Console.WriteLine("No known persons detected");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        /// Get or create a PersonGroup
        private static async Task<PersonGroup> createGroup(string groupId, string groupName)
        {
            Task<PersonGroup> result = null;

            //Trying to get group specified by groupId
            try
            {
                var tGet = face_api.GetPersonGroupAsync(groupId);
                tGet.Wait();
                result = tGet;
                Console.WriteLine("Group already exists with groupID = " + groupId + " groupName = " + groupName);
            }
            catch (Exception)
            {
                //If the group does not exist, create it
                Task tCreate = face_api.CreatePersonGroupAsync(groupId, groupName);
                tCreate.Wait();

                var tGet = face_api.GetPersonGroupAsync(groupId);
                tGet.Wait();
                result = tGet;
                Console.WriteLine("Group created with groupID = " + groupId + " groupName = " + groupName);
            }
            return result.Result;
        }


        /// Add a person and his training images to a specific group
        private static async void addPersonToGroup(string groupId, string personName, List<string> imagePaths)
        {
            try
            {
                Task<AddPersistedFaceResult>[] addedFaces = new Task<AddPersistedFaceResult>[imagePaths.Count];

                // Allocate new person in group
                var newPerson = face_api.CreatePersonAsync(groupId, personName);
                newPerson.Wait();
                var person = newPerson.Result;
                Console.WriteLine("New person initiated with name = " + personName);

                // Send person's photos 
                for (int i = 0; i < imagePaths.Count; i++)
                {
                    System.IO.Stream ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(imagePaths[i]));
                    addedFaces[i] = face_api.AddPersonFaceAsync(groupId, person.PersonId, ms);
                    Console.WriteLine("Sending training image(" + imagePaths[i] + ") for person = " + personName);
                }
                Task.WaitAll(addedFaces);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to add person to their group");
                throw;
            }

        }
        /// Train the PersonGroup        
        private static async void trainPersonGroup(string groupId)
        {
            try
            {
                Console.WriteLine("Training whole group with groupID = " + groupId);
                var t = face_api.TrainPersonGroupAsync(groupId);
                t.Wait();

                /*// Wait till group training finishes
                TrainingStatus trainingStatus = null;
                while (true)
                {
                    trainingStatus = await face_api.GetPersonGroupTrainingStatusAsync(groupId);
                    if ( trainingStatus.Status.Equals("succeeded") )
                    {
                        break;
                    }
                    await Task.Delay(1000);
                }
                Console.WriteLine("Group sucessfully trained"); */
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Unable to train group\n" + e.Message );
                throw;
            }
        }

        /// Identify a person in photo and match to a specific PersonGroup        
        private static async Task<IdentifyResult[]> identifyPersons(string groupId, string filePath)
        {
            try
            {
                Task<Face[]> detectedFaces = face_api.DetectAsync(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(filePath)));
                detectedFaces.Wait();
                List<IdentifyResult> result = new List<IdentifyResult>();

                if (detectedFaces.Result != null && detectedFaces.Result.Length > 0)
                {
                    List<Guid> faceIds = new List<Guid>();
                    detectedFaces.Result.ToList().ForEach(t => faceIds.Add(t.FaceId));

                    Task<IdentifyResult[]> matchedFaces = face_api.IdentifyAsync(groupId, faceIds.ToArray() );
                    matchedFaces.Wait();

                    if (matchedFaces.Result != null && matchedFaces.Result.Length > 0)
                    {
                        return matchedFaces.Result;
                    }
                    else
                        throw new ApplicationException("Faces detected. No match found");
                }
                else
                    throw new ApplicationException("No Faces detected in new Image");
            }
            catch (Exception)
            {
                Console.WriteLine("Error in identify person");
                throw;
            }
        }

        /// Return a PersonObject by personID within a group with groupId           
        private static async Task<Person> getPersonById(string groupId, Guid personId)
        {
            try
            {
                var t = face_api.GetPersonAsync(groupId, personId);
                t.Wait();
                return t.Result;
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get person by ID");
                throw;
            }

        }    
    }
}
