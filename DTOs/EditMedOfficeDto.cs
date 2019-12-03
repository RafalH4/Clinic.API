using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs
{
    public class EditMedOfficeDto
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public int OfficeNumber { get; set; }
        public string Description { get; set; }
    }
}
