using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentDto mapToDepartmentDto(this Department department)
        {
            var newDepartment = new DepartmentDto();
            newDepartment.Id = department.Id;
            newDepartment.Name = department.Name;
            newDepartment.PhoneNumber = department.PhoneNumber;
            newDepartment.Descriptcion = department.Descriptcion;
 
            return newDepartment;
        }

        public static DepartmentDetailDto mapToDepartmentDetailDto(this Department department)
        {
            var newDepartment = new DepartmentDetailDto();
            newDepartment.Id = department.Id;
            newDepartment.Name = department.Name;
            newDepartment.PhoneNumber = department.PhoneNumber;
            newDepartment.Descriptcion = department.Descriptcion;
            var contracts = new List<ContractDto>();
            var medOffices = new List<MedOfficeDto>();
            foreach (var contract in department.Contracts)
                contracts.Add(contract.mapToContractDto());

            foreach (var medOffice in department.MedOffices)
                medOffices.Add(medOffice.mapToMedOfficeDto());

            newDepartment.Contracts = contracts;
            newDepartment.MedOffices = medOffices;

            return newDepartment;
        }

    }
}
