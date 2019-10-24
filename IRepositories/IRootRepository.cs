using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IRootRepository
    {
        Task<IEnumerable<Root>> Get();
        Task<Root> GetById(Guid id);
        Task<Root> GetByEmail(string email);
        Task<Root> GetByPesel(string pesel);
        Task AddRoot(Root root);
        Task UpdateRoot(Root root);
        Task DeleteRoot(Root root);
    }
}
