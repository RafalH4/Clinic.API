﻿using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DataContext _context;
        public AppointmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAppointment(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task AddListAppointments(List<Appointment> appointments)
        {
            await _context.Appointments.AddRangeAsync(appointments);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;

        }

        public async Task DeleteAppointment(Appointment appointment)
        {
             _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Appointment>> Get()
            => await Task.FromResult(_context.Appointments.ToList());

        public async Task<IEnumerable<Appointment>> GetWithFilters(DateTime? startDate, DateTime? endDate, Guid? doctorId, 
            Guid? patientId, Guid? medOfficeId, bool? isFree)
        {
            var appointments = await Task.FromResult(_context.Appointments
                .Include(x => x.MedOffice)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ToList());
            DateTime? a = null;
            if (startDate is DateTime newStartDate)
                appointments = appointments.Where(appointment => DateTime.Compare(appointment.Date, newStartDate) >0).ToList();
            if (startDate is DateTime newEndDate)
                appointments = appointments.Where(appointment => DateTime.Compare(appointment.Date, newEndDate) < 0).ToList();
            if (doctorId is Guid newdoctorId)
                appointments = appointments.Where(appointment => appointment.Doctor.Id==doctorId).ToList();
            if (patientId is Guid newPatientId)
                appointments = appointments.Where(appointment => appointment.Patient.Id == newPatientId).ToList();
            if (medOfficeId is Guid newMedOfficeId)
                appointments = appointments.Where(appointment => appointment.MedOffice.Id == newMedOfficeId).ToList();


         //   if (isFree is bool newIsFree)
       //         appointments = appointments.Where(appointment => appointment.Patient.Equals(null)).ToList();
            return appointments;
        }


    }
}
