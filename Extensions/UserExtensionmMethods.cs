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
    }
}
