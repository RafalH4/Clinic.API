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
        Task<Department> AddDepartment(Department Department);
        Task<Department> UpdateDepartment(Department Department);
        Task<Department> DeleteDepartment(Department Department);
    }
}
