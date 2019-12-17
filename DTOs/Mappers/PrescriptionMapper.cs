using Clinic.API.DTOs.Get;
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

        public static PrescriptionDto MapToPrescriptionDto(this Prescription prescription)
        {
            var prescriptionDto = new PrescriptionDto();
            var appointment = prescription.Appointment.mapToAppointmentDto();
            if (appointment == null)
                throw new Exception("Appointment cant be null");
            prescriptionDto.Appointment = appointment;
            prescriptionDto.CreatedAt = prescription.CreatedAt;
            prescriptionDto.DrugName = prescription.Drug;
            prescriptionDto.Id = prescription.Id;

            return prescriptionDto;

        }
    }
}
