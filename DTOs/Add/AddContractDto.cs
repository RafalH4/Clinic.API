﻿using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs
{
    public class AddContractDto
    {
        public DateTime StartDate { get; set; }
        public int NumberOfMonths { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid DoctorId { get; set; }
        public int HoursPerMonth { get; set; }
        public int SalaryPerMonth { get; set; }
    }
}
