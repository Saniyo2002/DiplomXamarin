using System.Security.Cryptography;
using System.Text;

namespace diplomApiV4.Security
{
    public class Sha256Hasher : IPasswordHasher
    {
        public string CalculateHash(string password)
        {
            byte[] pass = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA256.HashData(pass);
            return Convert.ToBase64String(hashBytes);
        }

        public bool CheckPassword(string password, string hashFromDatabase)
        {
            var hash = CalculateHash(password);
            return hash == hashFromDatabase;
        }
    }
}
