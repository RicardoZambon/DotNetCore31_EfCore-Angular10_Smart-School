using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace SmartSchool.DAL.Security
{
    public static class PasswordHash
    {
        public static string Create(long userId, string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: BitConverter.GetBytes(userId),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 512 / 8));
            return hashed;
        }
    }
}
