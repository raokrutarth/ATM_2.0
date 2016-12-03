using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AtmServer
{
    internal sealed class Encryptor
    {
        private const string Salt = "d5fg49df5sg4ds5fg45sdfg4";
        private const int SizeOfBuffer = 1024 * 8; // buffer size for stream copy
        internal static string enc_key = ConfigurationManager.AppSettings["encKey"];
        internal static string enc_iv = ConfigurationManager.AppSettings["encIv"];


        internal static void EncryptFile(string inputPath, string outputPath)
        {
            string password = enc_key;
            var input = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            var output = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Write);

            // RijndaelManaged as AES :
            // 1.The block size is set to 128 bits
            // 2. not using CFB mode, or if CFB then feedback size is also 128 bits

            var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
            var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(Salt));

            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

            using (var encryptedStream = new CryptoStream(output, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
            {
                CopyStream(input, encryptedStream);
            }
        }

        internal static void DecryptFile(string inputPath, string outputPath)
        {
            string password = enc_key;           
            var input = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            var output = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Write);
            
            var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
            var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(Salt));

            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

            try
            {
                using (var decryptedStream = new CryptoStream(output, algorithm.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    CopyStream(input, decryptedStream);
                }
            }
            catch (CryptographicException)
            {
                throw new InvalidDataException("Please suppy a correct password");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void CopyStream(Stream input, Stream output)
        {
            using (output)
            using (input)
            {
                byte[] buffer = new byte[SizeOfBuffer];
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, read);
                }
            }
        }        

        internal static byte[] EncryptStringToBytes(string plainText)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(enc_key);
            byte[] iv = UE.GetBytes(enc_iv);

            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("[-] Invalid PlainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("[-] Invalid key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("[-] Invalid iv");


            byte[] encrypted;
            // RijndaelManaged object with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        internal static string DecryptStringFromBytes(byte[] cipherText)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(enc_key);
            byte[] iv = UE.GetBytes(enc_iv);

            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("[-] invalid cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("[-] invalid key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("[-] invalid key");

            // string used to hold the decrypted text.
            string plaintext;
            using (var rijAlg = new RijndaelManaged() )
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream and place in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

    }
}
