using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Add
{
    public class AddAnamnesisToAppointmentDto
    {
        public Guid Id{ get; set; }
        public string Anamnesis { get; set; }
    }
}
