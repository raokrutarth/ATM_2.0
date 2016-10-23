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