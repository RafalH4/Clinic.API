﻿using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Filters
{
    public class AppointmentFilter
    {
        public DateTime Date { get; set; }
        public MedOffice MedOffice { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
