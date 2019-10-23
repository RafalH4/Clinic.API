using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface INurseService
    {
        Task<IEnumerable<Nurse>> GetAll();
        Task<Nurse> GetById(Guid id);
        Task<Nurse> GetByPesel(string pesel);
        Task<Nurse> GetByEmail(string email);
        Task AddNurse(string email, string password,
            string pesel, string firstName, string secondName,
            string phoneNumber, string postCode, string city,
            string street, string houseNumber);
        Task DeleteNurse(Guid id);
        Task UpdateNurse(Guid id, string street, string postCode, string phoneNumber, string city);
    }
}
