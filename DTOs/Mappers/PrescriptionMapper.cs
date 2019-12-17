using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class PrescriptionMapper
    {
        public static Prescription MapToPrescription(this AddPrescriptionDto prescriptionDto, Appointment appointment)
        {
            var prescription = new Prescription();
            prescription.CreatedAt = DateTime.Now;
            prescription.Drug = prescriptionDto.Drug;
            if (appointment != null)
                prescription.Appointment = appointment;
            return prescription;

        }
    }
}
