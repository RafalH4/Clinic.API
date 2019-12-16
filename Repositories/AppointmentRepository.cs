using Clinic.API.Data;
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
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Appointment>> Get()
            => await Task.FromResult(_context.Appointments.ToList());

        public async Task<IEnumerable<Appointment>> GetWithFilters(DateTime? startDate, DateTime? endDate, Guid? doctorId,
            Guid? patientId, Guid? medOfficeId, string? departmentName, bool? isFree)
        {
            var appointments = await Task.FromResult(_context.Appointments
                .Include(x => x.MedOffice)
                .Include(x => x.MedOffice.Department)
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ToList());

            if (startDate is DateTime newStartDate)
                appointments = appointments.Where(appointment => DateTime.Compare(appointment.Date, newStartDate) >= 0).ToList();
            if (endDate is DateTime newEndDate)
                appointments = appointments.Where(appointment => DateTime.Compare(appointment.Date, newEndDate) <= 0).ToList();
            if (departmentName is string newDepartmentName)
                appointments = appointments.Where(appointment => appointment.MedOffice.Department.Name == newDepartmentName).ToList();
            if (doctorId is Guid newdoctorId)
                appointments = appointments.Where(appointment => appointment.Doctor.Id == newdoctorId).ToList();
            if (patientId is Guid newPatientId)
                appointments = appointments.Where(appointment => appointment.Patient?.Id == newPatientId).ToList();
            if (medOfficeId is Guid newMedOfficeId)
                appointments = appointments.Where(appointment => appointment.MedOffice.Id == newMedOfficeId).ToList();
            if (isFree == true)
                appointments = appointments.Where(appointment => appointment.Patient == null).ToList();
            return appointments.OrderBy(d => d.Date);
        }

        public async Task<Appointment> GetById(Guid id)
            => await Task.FromResult(_context.Appointments.SingleOrDefault(
                appointment => appointment.Id == id));

        public async Task<IEnumerable<Appointment>> GetByPatient(Patient patient)
             => await Task.FromResult(_context.Appointments
                .Include(x => x.MedOffice)
                .Include(x => x.Doctor)
                .Where(appointment => appointment.Patient.Equals(patient)).ToList());

        public async Task<IEnumerable<Appointment>> GetByDoctor(Doctor doctor)
             => await Task.FromResult(_context.Appointments
                .Include(x => x.MedOffice)
                .Include(x => x.Patient)
                .Where(appointment => appointment.Patient.Equals(doctor)).ToList());
    }
}
