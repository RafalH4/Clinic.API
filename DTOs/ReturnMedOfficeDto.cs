using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs
{
    public class ReturnMedOfficeDto
    {
        public Guid Id { get; set; }
        public List<Appointment> Appointments { get; set; }
        public string Department { get; set; }
        public int OfficeNumber { get; set; }
        public string Description { get; set; }
    }
}
