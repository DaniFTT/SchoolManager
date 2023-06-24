using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SchoolManager.SharedKernel.Extesions
{
    public static class StringExtesions
    {
        public static string ToHash(this string input)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hash[..Math.Min(hash.Length, 60)];
        }

        public static bool ContainsUppercase(this string password)
        {
            return password.Any(char.IsUpper);
        }
        public static bool ContainsLowercase(this string password)
        {
            return password.Any(char.IsLower);
        }

        public static bool ContainsNumber(this string password)
        {
            return password.Any(char.IsDigit);
        }

        public static bool ContainsSpecialCharacter(this string password)
        {
            var specialCharacters = "!@#$%^&*()-_=+[{}];:'\",.<>/?";
            return password.Any(c => specialCharacters.Contains(c));
        }
    }
}
