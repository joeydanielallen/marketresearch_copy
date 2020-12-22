using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace afmr.api.Cryptography
{
    public static class Cryptographer
    {
        //Encoding.UTF8.GetBytes("Pr0j3ct0dyss3usV3rt1pr1m3F0rL1f3")
        private static byte[] keyBytes = { 80, 114, 48, 106, 51, 99, 116, 48, 100, 121, 115, 115, 51, 117, 115, 86, 51, 114, 116, 49, 112, 114, 49, 109, 51, 70, 48, 114, 76, 49, 102, 51 };
        //System.Text.Encoding.ASCII.GetBytes("marketresearch!!")
        private static byte[] vector = { 109, 97, 114, 107, 101, 116, 114, 101, 115, 101, 97, 114, 99, 104, 33, 33 };

        public static string Encrypt(string content)
        {
            using (Aes aesAlg = Aes.Create())
            {
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(keyBytes, vector);
                
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(content);
                        }
                        return Convert.ToBase64String( msEncrypt.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string encryptedContent)
        {
            var encyrptedBytes = Convert.FromBase64String(encryptedContent);

            using (Aes aesAlg = Aes.Create())
            {
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(keyBytes, vector);

                using (MemoryStream msDecrypt = new MemoryStream(encyrptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
