using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDetailDto>> GetAll();
        Task<DepartmentDetailDto> GetById(Guid id);
        Task<DepartmentDetailDto> GetByName(string name);
        Task AddDepartment(AddDepartmentDto department);
        Task UpdateDepartment(AddDepartmentDto department, Guid id);
        Task DeleteDepartment(Guid id);
    }
}
