using System.Security.Cryptography;
using System.Text;

namespace Roster.Core;

public class PasswordHasher
{
    public string HashPassword(string plainTextPassword)
    {
        SHA256 shHash = SHA256.Create();
        UnicodeEncoding encoding = new();
        byte[] passwordBytes = encoding.GetBytes(plainTextPassword);
        byte[] hashedPasswordBytes = shHash.ComputeHash(passwordBytes);
        return Convert.ToBase64String(hashedPasswordBytes);
    }
}