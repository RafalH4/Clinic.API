using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    interface IPatientRepository
    {
        Task<Patient> Get(Guid id);
        Task<Patient> GetByEmail(string email);
        Task<Patient> GetByPesel(string pesel);
        Task<Patient> AddPatient(Patient doctor);
        Task<Patient> UpdatePatient(Patient doctor);
        Task<Patient> DeletePatient(Patient doctor);
    }
}
