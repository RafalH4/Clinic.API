using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetById(Guid id);
        Task<Doctor> GetByPesel(string pesel);
        Task<Doctor> GetByEmail(string email);
        Task<IEnumerable<Doctor>> GetByMedArea(Guid id);
        Task<IEnumerable<Doctor>> GetByPatient(Guid pesel);
        Task<IEnumerable<Doctor>> GetByMedOffice(Guid id);
        Task AddDoctor(string email, string password, 
            string pesel, string firstName, string secondName,
            string phoneNumber, string postCode, string city, 
            string street, string houseNumber);
        Task DeleteDoctor(Guid id);
        Task UpdateDoctor(Guid id, string email, string password,
            string firstName, string secondName,
            string phoneNumber, string postCode,
            string city, string street, string houseNumber);

    }
}
