using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Descriptcion { get; set; }
        public List<Models.Contract> Contracts { get; set; }
        public List<MedOffice> MedOffices { get; set; }
    }
}
