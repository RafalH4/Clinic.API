using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class MedOffice
    {
        public Guid Id { get; set; }
        public List<Appointment> Appointments { get; set; }
        public Department department { get; set; }
        public int OfficeNumber { get; set; }
        public string Description { get; set; }

    }
}
