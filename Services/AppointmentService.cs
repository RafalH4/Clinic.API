using Clinic.API.DTOs;
using Clinic.API.Filters;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using Clinic.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.API.DTOs.Get;
using Clinic.API.DTOs.Mappers;
using Clinic.API.DTOs.Add;

namespace Clinic.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMedOfficeRepository _medOfficeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMedAreaRepository _medAreaRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentrepository,
                    IMedOfficeRepository medOfficeRepository,
                    IUserRepository userRepository,
                    IMedAreaRepository medAreaRepository,
                    IDoctorRepository doctorRepository,
                    IPatientRepository patientRepositry)
        {
            _appointmentRepository = appointmentrepository;
            _medOfficeRepository = medOfficeRepository;
            _userRepository = userRepository;
            _medAreaRepository = medAreaRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepositry;
        }
        async public Task AddAppointment(AddAppointmentDto appointment)
        {
            var medOffice = await _medOfficeRepository.GetById(appointment.MedOfficeId);
            if (medOffice == null)
                throw new Exception("error in medOffice ID");
            var doctor = await _doctorRepository.GetById(appointment.DoctorId);
            doctor.ifUserNotExists("Error with selected doctor");


            //sprawdzić, czy w tych godzinach gabinet i lekarz są wolni
            List<Appointment> appointments = new List<Appointment>();
            var startHour = DateTime.Parse(appointment.StartHour);
            var endHour = DateTime.Parse(appointment.EndHour);


            appointment.Dates.ForEach(date =>
            {
                var startDate = date.AddHours(startHour.Hour)
                                    .AddMinutes(startHour.Minute);
                var endDate = date.AddHours(endHour.Hour)
                                  .AddMinutes(endHour.Minute);

                for (DateTime tempDate = startDate; tempDate < endDate; tempDate = tempDate.AddMinutes(appointment.RangeInMinutes))
                {
                    appointments.Add(new Appointment
                    {
                        Id = Guid.NewGuid(),
                        Date = tempDate,
                        Doctor = doctor,
                        MedOffice = medOffice,
                    });
                }
  
            });
            await _appointmentRepository.AddListAppointments(appointments);

        }

        public async Task AddPatientToAppointment(AddUserToAppointmentDto assigment)
        {
            var patient = await _patientRepository.GetById(assigment.UserId);
            if (patient == null)
                throw new Exception("bad patient id");
            var appointment = await _appointmentRepository.GetById(assigment.AppointmentId);
            if (appointment == null)
                throw new Exception("bad appointment it");

            appointment.Patient = patient;

            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task DeleteAppointment(Guid id)
        {
            var appointment = await _appointmentRepository.GetById(id);
            if (appointment == null)
                throw new Exception("bad appointmentId");
            await _appointmentRepository.DeleteAppointment(appointment);
        }

        public Task<IEnumerable<AppointmentDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppointmentDto>> GetWithFilter(DateTime? startDate,
            DateTime? endDate, 
            Guid? doctorId, 
            Guid? patientId, 
            Guid? medOfficeId,
            string? departmentName, 
            bool? isFree) {
            var appointments = await _appointmentRepository.GetWithFilters(startDate, endDate, doctorId, patientId, medOfficeId, departmentName, isFree);
            var appointmentsDto = new List<AppointmentDto>();
            foreach(var appointment in appointments)
                appointmentsDto.Add(appointment.mapToAppointmentDto());

            return appointmentsDto;
            
        }
        

        public Task ModifyAppointment(AddAppointmentDto appointment)
        {
            throw new NotImplementedException();
        }
    }
}
