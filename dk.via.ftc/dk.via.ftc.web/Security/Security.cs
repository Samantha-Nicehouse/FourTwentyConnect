using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace dk.via.ftc.web.Security
{
    public class Security
    {
        public static string HashPassword(string password)
        {
            // 128-bit salt
            byte[] salt = new byte[128 / 8];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash password
            string hashedPass = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPass;
        }
    }
}