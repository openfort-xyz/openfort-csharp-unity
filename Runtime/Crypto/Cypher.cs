using System;
using System.Security.Cryptography;
using System.Text;

namespace Openfort.Crypto
{
    public static class Cypher
    {
        public static string DeriveKey(string password, string salt)
        {
            using var rfc2898 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 1000, HashAlgorithmName.SHA256);
            return Convert.ToBase64String(rfc2898.GetBytes(256 / 8));
        }

        public static string Encrypt(string key, string data)
        {
            var aes = Aes.Create();
            aes.Key = Convert.FromBase64String(key);
            aes.GenerateIV();
        
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(data), 0, data.Length);

            var result = new byte[aes.IV.Length + encrypted.Length];
            Array.Copy(aes.IV, 0, result, 0, aes.IV.Length);
            Array.Copy(encrypted, 0, result, aes.IV.Length, encrypted.Length);

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string key, string encryptedData)
        {
            var combined = Convert.FromBase64String(encryptedData);
            var aes = Aes.Create();
            aes.Key = Convert.FromBase64String(key);

            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] encrypted = new byte[combined.Length - iv.Length];

            Array.Copy(combined, iv, iv.Length);
            Array.Copy(combined, iv.Length, encrypted, 0, encrypted.Length);

            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            var decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
            return Encoding.UTF8.GetString(decrypted);
        }

        public static string GenerateRandomSalt(int size = 16) 
        {
            var rng = RandomNumberGenerator.Create();
            var buffer = new byte[size];
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
    }
}