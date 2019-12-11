using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.DTOs.Mappers;
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

        public async Task<IEnumerable<DepartmentDetailDto>> GetAll()
        {
            var departments = await _departmentRepository.Get();
            var departmentsDetailDto = new List<DepartmentDetailDto>();
            foreach (var department in departments)
                departmentsDetailDto.Add(department.mapToDepartmentDetailDto());
            return departmentsDetailDto;
        }


        public async Task<DepartmentDetailDto> GetById(Guid id)
        {
            var department = await _departmentRepository.GetById(id);
            var departmentDetailDto = department.mapToDepartmentDetailDto();
            return departmentDetailDto;
        }

        public async Task<DepartmentDetailDto> GetByName(string name)
        {
            var department = await _departmentRepository.GetByName(name);
            var departmentDetailDto = department.mapToDepartmentDetailDto();
            return departmentDetailDto;
        }

        public async Task UpdateDepartment(AddDepartmentDto department, Guid id)
        {
            var depart = await _departmentRepository.GetById(id);
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
