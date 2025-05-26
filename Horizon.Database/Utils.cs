using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Horizon.Database
{
    public static class Utils
    {
        #region SHA-256

        public static string ComputeSHA256(string input)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string ComputeSHA512(string input)
        {
            // Compute hash value
            using (SHA512 sha512Hash = SHA512.Create())
            {
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert hash bytes to a string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        #endregion SHA-256

        #region Regex

        public static bool PassTextFilter(string text, string rExp)
        {
            if (String.IsNullOrEmpty(rExp))
                return true;

            Regex r = new Regex(rExp, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return !r.IsMatch(text);
        }

        #endregion Regex
    }
}