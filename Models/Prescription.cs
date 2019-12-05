using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Appointment Appointment { get; set; }
        public Guid AppointmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Drug Drug { get; set; }
        public Guid DrugId { get; set; }

    }
}
