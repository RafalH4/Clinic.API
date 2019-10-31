using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IAuthRepository
    {
        Task<Patient> Register(Patient patient, string password);
        Task<Patient> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
