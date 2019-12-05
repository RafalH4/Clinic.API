using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
        Task<User> GetByPesel(string pesel);
        Task UpdateUser(User user);
    }
}
