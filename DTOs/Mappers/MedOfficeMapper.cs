using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class MedOfficeMapper
    {
        public static MedOfficeDto mapToMedOfficeDto(this MedOffice office)
        {
            var newOfficeDto = new MedOfficeDto();
            newOfficeDto.Id = office.Id;
            newOfficeDto.Description = office.Description;
            newOfficeDto.OfficeNumber = office.OfficeNumber;
            
            var newDepartmentDto = new DepartmentDto();
            newDepartmentDto.Id = office.Department.Id;
            newDepartmentDto.Name = office.Department.Name;
            newDepartmentDto.PhoneNumber = office.Department.PhoneNumber;
            newDepartmentDto.Descriptcion = office.Department.Descriptcion;

            newOfficeDto.Department = newDepartmentDto;

            return newOfficeDto;
        }

    }
}
