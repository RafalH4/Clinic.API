using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public DateTime SignedAt { get; set; }
        public int NumberOfMonths { get; set; }
        public int HoursPerMonth { get; set; }
        public int SalaryPerMonth { get; set; }
    }
}
