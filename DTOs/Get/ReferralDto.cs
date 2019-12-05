using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class ReferralDto
    {
        public Guid Id { get; set; }
        public AppointmentDto Appointment { get; set; }
        public DateTime CreatedAt { get; set; }
        public TreatmentDto Treatment { get; set; }
    }
}
