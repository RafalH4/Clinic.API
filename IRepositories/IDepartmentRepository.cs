using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IDepartmentRepository
    {
        Task<Department> Get(Guid id);
        Task<Department> GetByName(string name);
        Task<Department> GetByMedOffice(MedOffice medOffice);
        Task AddDepartment(Department department);
        Task UpdateDepartment(Department department);
        Task DeleteDepartment(Department department);
    }
}
