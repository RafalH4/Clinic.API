using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    interface IContractService
    {
        Task<IEnumerable<Contract>> GetAll();
        Task<IEnumerable<Contract>> GetWithParameters();
        Task AddContract();
        Task DeleteContract();
        Task ModifyContract();
    }
}
