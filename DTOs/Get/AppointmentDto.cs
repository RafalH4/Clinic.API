using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Get
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Anamnesis { get; set; }
        public List<ReferralDto> Referrals { get; set; }
        public List<PrescriptionDto> Prescriptions { get; set; }
        public MedOfficeDto MedOffice { get; set; }
        public PatientDto Patient { get; set; }
        public DoctorDto Doctor { get; set; }
    }
}
