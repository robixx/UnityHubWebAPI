using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using UnityHubWebAPI.IServices;

namespace UnityHubWebAPI.Services
{
    public class CommonService : ICommonService
    {
        private const int SaltSize = 16;
        private const int Iterations = 10000;
        private const int HashSize = 32;
        public (string hashedPassword, string salt) HashPassword(string password)
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            byte[] hashBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: HashSize);

            string saltBase64 = Convert.ToBase64String(saltBytes);
            string hashBase64 = Convert.ToBase64String(hashBytes);

            return (hashBase64, saltBase64);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] storedHashBytes = Convert.FromBase64String(storedHash);

            byte[] enteredHashBytes = KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: HashSize);

            return CryptographicOperations.FixedTimeEquals(storedHashBytes, enteredHashBytes);
        }
    }
}
