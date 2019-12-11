using Clinic.API.DTOs.Get;
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
            return newOfficeDto;
        }

        public static MedOfficeDetailDto mapToMedOfficeDetailDto(this MedOffice office)
        {
            var newOfficeDetailDto = new MedOfficeDetailDto();
            newOfficeDetailDto.Id = office.Id;
            newOfficeDetailDto.Description = office.Description;
            newOfficeDetailDto.OfficeNumber = office.OfficeNumber;
            if (office.Department != null)
                newOfficeDetailDto.Department = office.Department.mapToDepartmentDto();

            return newOfficeDetailDto;
        }

    }
}
