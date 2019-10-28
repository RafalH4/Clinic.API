using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IRootService
    {
        Task<IEnumerable<Root>> GetAll();
        Task<Root> GetById(Guid id);
        Task<Root> GetByPesel(string pesel);
        Task<Root> GetByEmail(string email);
        Task AddRoot(string email, string password,
            string pesel, string firstName, string secondName,
            string phoneNumber, string postCode, string city,
            string street, string houseNumber);
        Task DeleteRoot(Guid id);
        Task UpdateRoot(Guid id, string street, string postCode, string phoneNumber, string city);
    }
}
