using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> Get();
        Task<IEnumerable<Contract>> GetByDoctor(Doctor doctor);
        //Task<IEnumerable<Contract>> GetByMedArea(MedArea medArea);
        Task<IEnumerable<Contract>> GetByDepartment(Guid id);
        Task<Contract> GetByDoctorAndDepartment(Doctor doctor, Department department);
        Task AddContract(Contract contract);
        Task DeleteContract(Contract contract);
        Task UpdateContract(Contract contract);

    }
}
