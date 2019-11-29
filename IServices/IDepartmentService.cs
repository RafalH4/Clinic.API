using Clinic.API.DTOs;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(Guid id);
        Task<Department> GetByName(string name);
        Task AddDepartment(AddDepartmentDto department);
        Task UpdateDepartment(AddDepartmentDto department);
        Task DeleteDepartment(Guid id);
    }
}
