﻿using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDto mapToAppointmentDto(this Appointment appointment)
        {
            var newAppointmentDto = new AppointmentDto();
            newAppointmentDto.Id = appointment.Id;
            newAppointmentDto.Date = appointment.Date;
            newAppointmentDto.Anamnesis = appointment.Anamnesis;
            if(appointment.MedOffice != null)
                newAppointmentDto.MedOffice = appointment.MedOffice.mapToMedOfficeDto();
            if (appointment.Patient != null)
                newAppointmentDto.Patient = appointment.Patient.mapToPatientDto();
            if (appointment.Doctor != null)
                newAppointmentDto.Doctor = appointment.Doctor.mapToDoctorDto();
           

            //Przypisać recepty i skierowania
            return newAppointmentDto;
        }
    }
}
