using Clinic.API.DTOs;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task AddDepartment(AddDepartmentDto department)
        {
            var depart = await _departmentRepository.GetByName(department.Name);
            if (depart != null)
            {
                throw new Exception("This department is used");
            }

            var newDepartment = new Department();
            newDepartment.Id = Guid.NewGuid();
            newDepartment.Name = department.Name;
            newDepartment.PhoneNumber = department.PhoneNumber;
            newDepartment.Descriptcion = department.Description;

            await _departmentRepository.AddDepartment(newDepartment);
        }
        public async Task DeleteDepartment(Guid id)
        {
            var depart = await _departmentRepository.GetById(id);
            if (depart == null)
            {
                throw new Exception("Wrong department");
            }
            await _departmentRepository.DeleteDepartment(depart);
        }

        public async Task<IEnumerable<Department>> GetAll()
        => await _departmentRepository.Get();

        public async Task<Department> GetById(Guid id)
        => await _departmentRepository.GetById(id);

        public async Task<Department> GetByName(string name)
        => await _departmentRepository.GetByName(name);
        public async Task UpdateDepartment(AddDepartmentDto department)
        {
            var depart = await _departmentRepository.GetByName(department.Name);
            if (depart == null)
            {
                throw new Exception("Wrong department");
            }
            depart.Name = department.Name;
            depart.PhoneNumber = department.PhoneNumber;
            depart.Descriptcion = department.Description;

            await _departmentRepository.UpdateDepartment(depart);
        }
    }
}
