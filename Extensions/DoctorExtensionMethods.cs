using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Extensions
{
    public static class DoctorExtensionMethods
    {
        public static void ifDoctorExists(this Doctor doctor, string text)
        {
            if (doctor != null)
            {
                throw new Exception(text);
            }
        }

        public static void ifDoctorNotExists(this Doctor doctor, string text)
        {
            if (doctor == null)
            {
                throw new Exception(text);
            }
        }
    }
}
