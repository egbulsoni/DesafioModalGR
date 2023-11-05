using System;
using System.Security.Cryptography;
using System.Text;

namespace DesafioModalGR
{

    class CofreEletronico
    {
        public static void Executar()
        {
            // Key should be 8 bytes long
            string key = "#modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista";
            string password1 = "EduardoLogando";
            string password2 = "#SomosModal2023";
            string password3 = "MinhaSenhaQualquer";

            CriarChaveDES(key, password1);

            CriarChave3DES(key, password2);

            CriarChaveRijndael(key, password3);
        }

        private static void CriarChaveRijndael(string key, string password3)
        {
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                byte[] derivedKey = DeriveKey32(key);

                rijAlg.Key = derivedKey;
                rijAlg.IV = Encoding.ASCII.GetBytes("1234567890123456"); // Initialization Vector

                // String to encrypt
                string plaintext = password3;

                // Encrypt the plaintext
                byte[] ciphertext = EncryptRijndael(rijAlg, plaintext);

                // Encode the encrypted data as base64 for easy printing
                string encryptedBase64 = Convert.ToBase64String(ciphertext);

                Console.WriteLine("Encrypted String: " + encryptedBase64);
            }
        }

        private static void CriarChave3DES(string key, string password2)
        {
            using (TripleDESCryptoServiceProvider desAlg = new TripleDESCryptoServiceProvider())
            {
                byte[] derivedKey = DeriveKey24(key);

                desAlg.Key = derivedKey;
                desAlg.IV = Encoding.ASCII.GetBytes("aaaaaaaa"); // Initialization Vector

                // String to encrypt
                string plaintext = password2;

                // Ensure the plaintext is a multiple of 8 (DES block size)
                int padding = 8 - (plaintext.Length % 8);
                plaintext += new string(' ', padding);

                // Encrypt the plaintext
                byte[] plaintextBytes = Encoding.ASCII.GetBytes(plaintext);
                byte[] ciphertext = Encrypt3DES(desAlg, plaintextBytes);

                // Encode the encrypted data as base64 for easy printing
                string encryptedBase64 = Convert.ToBase64String(ciphertext);

                Console.WriteLine("Encrypted String: " + encryptedBase64);
            }
        }

        private static void CriarChaveDES(string key, string password1)
        {
            using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
            {
                byte[] derivedKey = DeriveKey(key);

                desAlg.Key = derivedKey;
                desAlg.IV = Encoding.ASCII.GetBytes("aaaaaaaa"); // Initialization Vector

                // String to encrypt
                string plaintext = password1;

                // Ensure the plaintext is a multiple of 8 (DES block size)
                int padding = 8 - (plaintext.Length % 8);
                plaintext += new string(' ', padding);

                // Encrypt the plaintext
                byte[] plaintextBytes = Encoding.ASCII.GetBytes(plaintext);
                byte[] ciphertext = Encrypt(desAlg, plaintextBytes);

                // Encode the encrypted data as base64 for easy printing
                string encryptedBase64 = Convert.ToBase64String(ciphertext);

                Console.WriteLine("Encrypted String: " + encryptedBase64);
            }
        }

        static byte[] DeriveKey32(string passphrase)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passphrase, new byte[0], 10000))
            {
                return pbkdf2.GetBytes(32); // 32 bytes for a 256-bit key
            }
        }

        static byte[] EncryptRijndael(RijndaelManaged rijAlg, string plaintext)
        {
            using (ICryptoTransform encryptor = rijAlg.CreateEncryptor())
            {
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

                using (MemoryStream memoryStream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        static byte[] DeriveKey(string passphrase)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passphrase, new byte[0], 10000))
            {
                return pbkdf2.GetBytes(8); // 8 bytes for an 8-byte key
            }
        }
        static byte[] DeriveKey24(string passphrase)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passphrase, new byte[0], 10000))
            {
                return pbkdf2.GetBytes(24); // 24 bytes for a 192-bit key
            }
        }

        static byte[] Encrypt3DES(TripleDESCryptoServiceProvider desAlg, byte[] plaintext)
        {
            using (ICryptoTransform encryptor = desAlg.CreateEncryptor(desAlg.Key, desAlg.IV))
            {
                return PerformCryptography(encryptor, plaintext);
            }
        }

        static byte[] Encrypt(DESCryptoServiceProvider desAlg, byte[] plaintext)
        {
            using (ICryptoTransform encryptor = desAlg.CreateEncryptor(desAlg.Key, desAlg.IV))
            {
                return PerformCryptography(encryptor, plaintext);
            }
        }


        static byte[] PerformCryptography(ICryptoTransform transform, byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return memoryStream.ToArray();
            }
        }
    }
}