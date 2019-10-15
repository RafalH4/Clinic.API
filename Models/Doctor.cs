using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Doctor : User
    {
        public List<Contract> Contracts { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
