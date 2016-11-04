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
        
    }
}