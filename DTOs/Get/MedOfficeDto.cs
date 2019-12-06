using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs
{
    public class MedOfficeDto
    {
        public Guid Id { get; set; }
        public int OfficeNumber { get; set; }
        public string Description { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
