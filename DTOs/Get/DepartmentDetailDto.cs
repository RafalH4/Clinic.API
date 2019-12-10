using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class DepartmentDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Descriptcion { get; set; }
        public List<MedOfficeDto> MedOffices { get; set; }
        public List<ContractDto> Contracts { get; set; }
    }
}
