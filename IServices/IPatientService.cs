using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetById(Guid id);
        Task<Patient> GetByPesel(string pesel);
        Task<Patient> GetByEmail(string email);
        Task AddPatient(string email, string password,
            string pesel, string firstName, string secondName,
            string phoneNumber, string postCode, string city,
            string street, string houseNumber);
        Task DeletePatient(Guid id);
        Task UpdatePatient(Guid id, string street, string postCode, string phoneNumber, string city);
    }
}
