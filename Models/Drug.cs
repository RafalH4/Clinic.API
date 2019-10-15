using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Drug
    {
        public List<Prescription> Prescriptions { get; set; }
    }
}
