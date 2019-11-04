using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Extensions
{
    public static class UserExtensionmMethods
    {
        public static void ifUserExists(this User user, string text)
        {
            if (user != null)
            {
                throw new Exception(text);
            }
        }

        public static void ifUserNotExists(this User user, string text)
        {
            if (user == null)
            {
                throw new Exception(text);
            }
        }
        public static bool checkPassword(this User user, string password)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return false;
            }
            return true;

        }
    }
}
