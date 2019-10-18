using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    interface IPatientRepository
    {
        Task<IEnumerable<Patient>> Get();
        Task<Patient> GetById(Guid id);
        Task<Patient> GetByEmail(string email);
        Task<Patient> GetByPesel(string pesel);
        Task AddPatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(Patient patient);
    }
}
