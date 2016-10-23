using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace AtmServer
{
    class Authenticator
    {
        public Authenticator()
        {
            /// select hashing algorithim
            /// test encrypt/decrypt
        }
        public Boolean verifyFace()
        {

            MakeFaceRequest();
            Console.WriteLine("Hit ENTER to exit...");
            return true;

            /*
             *   JSON fields in face to face verification request body:
        <table class="element table">
        <thead>
        <tr><th>Fields</th><th>Type</th><th>Description</th></tr>
        </thead>
        <tbody>
        <tr><td>faceId1</td><th>String</th><td>faceId of one face, comes from <a href="/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236">Face - Detect</a>.</td></tr>
        <tr><td>faceId2</td><th>String</th><td>faceId of another face, comes from <a href="/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236">Face - Detect</a>.<br />
        </tbody>
        </table>                       
        
        JSON fields in face to person verification request body:
        <table class="element table">
        <thead>
        <tr><th>Fields</th><th>Type</th><th>Description</th></tr>
        </thead>
        <tbody>
        <tr><td>faceId</td><th>String</th><td>faceId the face, comes from <a href="/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236">Face - Detect</a>.</td></tr>
        <tr><td>personGroupId</td><th>String</th><td>Using existing personGroupId and personId for fast loading a specified person. personGroupId is created in <a href="/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395244">Person Group - Create a Person Group</a>.</td></tr>
        <tr><td>personId</td><th>String</th><td>Specify a certain person in a person group. personId is created in <a href="/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f3039523c
        ">Person - Create a Person</a>.</td></tr>
        
        </tbody>
        </table>
             */
        }
        static async void MakeFaceRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{I will put our key here}");

            var uri = "https://api.projectoxford.ai/face/v1.0/verify?" + queryString;

            HttpResponseMessage response;

            // Request body put image in it (probably)
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("< content type, i.e. application/json >");
                response = await client.PostAsync(uri, content);
            }

        }
    }
}