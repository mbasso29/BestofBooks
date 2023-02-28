using System.Security.Cryptography;
using System.Text;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BestofBooks
{
    public static class SecurityUtilities
    {
        public static string HashPassword (string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException ("password");
            }
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }
    }
}
