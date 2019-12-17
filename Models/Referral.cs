﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Referral
    {
        public Guid Id { get; set; }
        public Appointment Appointment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Treatment { get; set; }
    }
}
