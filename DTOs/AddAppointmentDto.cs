using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs
{
    public class AddAppointmentDto
    {
        public List<DateTime> Dates { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int RangeInMinutes { get; set; }
        public Guid DoctorId { get; set; }
        public Guid MedOfficeId { get; set; }
        public Guid MedAreaId { get; set; }

    }
}
