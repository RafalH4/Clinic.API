using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
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

        public async Task<IEnumerable<Appointment>> GetBetweenDates(DateTime startDateTime, DateTime endDateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Date >= startDateTime && appointment.Date <= startDateTime)
                .ToList());

        public async Task<IEnumerable<Appointment>> GetByDate(DateTime dateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Date.Equals(dateTime))
                .ToList());

        public async Task<IEnumerable<Appointment>> GetByDoctor(Doctor doctor)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor))
                .ToList());

        public async Task<IEnumerable<Appointment>> GetByDoctorAndDate(Doctor doctor, DateTime dateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor))
                .Where(appointment => appointment.Date.Equals(dateTime))
                .ToList());

        public async Task<IEnumerable<Appointment>> GetByMedOfficeAndDate(MedOffice medOffice, DateTime dateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.MedOffice.Equals(medOffice))
                .Where(appointment => appointment.Date.Equals(dateTime))
                .ToList());

        public async Task<IEnumerable<Appointment>> GetByPatient(Patient patient)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Patient.Equals(patient))
                .ToList());

        public async Task<IEnumerable<Appointment>> GetByPatientAndDate(Patient patient, DateTime dateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Patient.Equals(patient))
                .Where(appointment => appointment.Date.Equals(dateTime))
                .ToList());

        public async Task<IEnumerable<Appointment>> GetByPatientBetweenDate(Patient patient, DateTime startDateTime, DateTime endDateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Patient.Equals(patient))
                .Where(appointment => appointment.Date >= startDateTime && appointment.Date <= startDateTime)
                .ToList());

        public async Task<IEnumerable<Appointment>> GetFreeAppointmentsByDoctor(Doctor doctor)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor) && appointment.Patient==null)
                .ToList());

        public async Task<IEnumerable<Appointment>> GetFreeAppointmentsByDoctorBetweenDates(Doctor doctor, DateTime startDateTime, DateTime endDateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor) && appointment.Patient == null)
                .Where(appointment => appointment.Date >= startDateTime && appointment.Date <= startDateTime)
                .ToList());

        public async Task<IEnumerable<Appointment>> GetFreeAppointmentsByDoctorWithDate(Doctor doctor, DateTime dateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor) && appointment.Patient == null)
                .Where(appointment => appointment.Date.Equals(dateTime))
                .ToList());

        public async Task<IEnumerable<Appointment>> GetReservedAppointmentsByDoctor(Doctor doctor)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor) && appointment.Patient != null)
                .ToList());

        public async Task<IEnumerable<Appointment>> GetReservedAppointmentsByDoctorBetweenDates(Doctor doctor, DateTime startDateTime, DateTime endDateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor) && appointment.Patient != null)
                .Where(appointment => appointment.Date >= startDateTime && appointment.Date <= startDateTime)
                .ToList());

        public async Task<IEnumerable<Appointment>> GetReservedAppointmentsByDoctorWithDate(Doctor doctor, DateTime dateTime)
            => await Task.FromResult(_context.Appointments
                .Where(appointment => appointment.Doctor.Equals(doctor) && appointment.Patient != null)
                .Where(appointment => appointment.Date.Equals(dateTime))
                .ToList());
    }
}
