﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Treatment
    {
        public Guid Id { get; set; }
        public List<Referral> Referrals { get; set; }
    }
}
