using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDetailsDto>> GetAll();
        Task<IEnumerable<ContractDetailsDto>> GetByDeparamentId(Guid id);
        Task AddContract(AddContractDto contract);
        Task DeleteContract(Guid Id);
        Task ModifyContract(AddContractDto contract);
    }
}
