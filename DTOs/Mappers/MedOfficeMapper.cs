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

          //  var newDepartmentDto = office.Department.mapToDepartmentDto();

          //  newOfficeDto.Department = newDepartmentDto;

            return newOfficeDto;
        }

    }
}
