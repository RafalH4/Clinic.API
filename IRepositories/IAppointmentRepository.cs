using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> Get();
        Task<IEnumerable<Appointment>> GetByDate(DateTime dateTime);
        Task<IEnumerable<Appointment>> GetByMedOfficeAndDate(MedOffice medOffice, DateTime dateTime);
        Task<IEnumerable<Appointment>> GetBetweenDates(DateTime startDateTime, DateTime endDateTime);
        //Get with doctor
        Task<IEnumerable<Appointment>> GetByDoctor(Doctor doctor);
        Task<IEnumerable<Appointment>> GetByDoctorAndDate(Doctor doctor, DateTime dateTime);
        Task<IEnumerable<Appointment>> GetFreeAppointmentsByDoctor(Doctor doctor);
        Task<IEnumerable<Appointment>> GetFreeAppointmentsByDoctorWithDate(Doctor doctor, DateTime dateTime);
        Task<IEnumerable<Appointment>> GetFreeAppointmentsByDoctorBetweenDates(Doctor doctor, 
            DateTime startDateTime, DateTime endDateTime);
        Task<IEnumerable<Appointment>> GetReservedAppointmentsByDoctor(Doctor doctor);
        Task<IEnumerable<Appointment>> GetReservedAppointmentsByDoctorWithDate(Doctor doctor, DateTime dateTime);
        Task<IEnumerable<Appointment>> GetReservedAppointmentsByDoctorBetweenDates(Doctor doctor,
            DateTime startDateTime, DateTime endDateTime);

        //Get with patient

        Task<IEnumerable<Appointment>> GetByPatient(Patient patient);
        Task<IEnumerable<Appointment>> GetByPatientAndDate(Patient patient, DateTime dateTime);
        Task<IEnumerable<Appointment>> GetByPatientBetweenDate(Patient patient,
            DateTime startDateTime, DateTime endDateTime);

        Task AddAppointment(Appointment appointment);
        Task DeleteAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
    }
}
