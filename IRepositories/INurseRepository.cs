using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
   public interface INurseRepository
    {
        Task<IEnumerable<Nurse>> Get();
        Task<Nurse> GetById(Guid id);
        Task<Nurse> GetByEmail(string email);
        Task<Nurse> GetByPesel(string pesel);
        Task AddNurse(Nurse nurse);
        Task UpdateNurse(Nurse nurse);
        Task DeleteNurse(Nurse nurse);
    }
}
