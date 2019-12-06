using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Contract
    {
        public Guid Id { get; set; }
        public DateTime SignedAt { get; set; }
        public int NumberOfMonths { get; set; }
        public Doctor Doctor { get; set; }
        public MedArea MedArea { get; set; }
        public int HoursPerMonth { get; set; }
        public int SalaryPerMonth { get; set; }
    }
}
