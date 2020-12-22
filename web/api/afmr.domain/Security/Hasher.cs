using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace afmr.domain.Security
{
    public static class Hasher 
    {
        public static string ComputeHash(
            string textToHash,
            string salt)
        {
            //validate
            if(string.IsNullOrEmpty(textToHash))
            {
                throw new ArgumentOutOfRangeException("plainText", "At least one character should exist");
            }

            if(string.IsNullOrEmpty(salt))
            {
                throw new ArgumentOutOfRangeException("salt", "At least one character should exist");
            }

            byte[] saltBytes = Encoding.Unicode.GetBytes(salt);
            
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textToHash);
            
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            HashAlgorithm hash = new SHA512Managed();

            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            return hashValue;
        }
    }
}
