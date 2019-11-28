using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs
{
    public class AddContractDto
    {
        public int NumberOfMonths { get; set; }
        public Department Department { get; set; }
        public Doctor Doctor { get; set; }
        public MedArea MedArea { get; set; }
        public int HoursPerMonth { get; set; }
        public int SalaryPerMonth { get; set; }
    }
}
