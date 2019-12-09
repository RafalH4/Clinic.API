using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class DoctorDetailDto : UserDto
    {
        public List<ContractDto> Contracts { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}
