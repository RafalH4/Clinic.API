using Clinic.API.DTOs;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IUserService
    {
        Task<bool> IfEmailAvaiable(string email);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task UpdateUser(UserDto user);
    }
}
