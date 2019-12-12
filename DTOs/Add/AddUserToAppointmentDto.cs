using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Add
{
    public class AddUserToAppointmentDto
    {
        public Guid UserId { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
