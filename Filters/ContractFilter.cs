using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Filters
{
    public class ContractFilter
    {
        public Department Department { get; set; }
        public Doctor Doctor { get; set; }
        public MedArea MedArea { get; set; }
        public DateTime SignedAt { get; set; }

    }
}
