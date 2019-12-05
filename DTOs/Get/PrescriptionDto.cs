using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class PrescriptionDto
    {
        public Guid Id { get; set; }
        public AppointmentDto Appointment { get; set; }
        public DateTime CreatedAt { get; set; }
        public Drug Drug { get; set; }
    }
}
