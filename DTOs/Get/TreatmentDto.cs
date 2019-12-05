using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class TreatmentDto
    {
        public Guid Id { get; set; }
        public List<ReferralDto> Referrals { get; set; }
    }
}
