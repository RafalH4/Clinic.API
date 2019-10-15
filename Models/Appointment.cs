using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Anamnesis { get; set; }
        public List<Referral> Referrals { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public MedOffice MedOffice { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public Appointment()
        {
            Anamnesis = "aaa";
        }


    }
}
