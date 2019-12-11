using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class ContractDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime SignedAt { get; set; }
        public int NumberOfMonths { get; set; }
        public DoctorDto Doctor { get; set; }
        public DepartmentDto Department { get; set; }
        public int HoursPerMonth { get; set; }
        public int SalaryPerMonth { get; set; }
        public string DoctorFullName { get; set; }
        public string DepartmentName { get; set; }
    }
}
