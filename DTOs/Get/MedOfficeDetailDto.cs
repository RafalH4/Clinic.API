using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class MedOfficeDetailDto
    {
        public Guid Id { get; set; }
        public int OfficeNumber { get; set; }
        public string Description { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
