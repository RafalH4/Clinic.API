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

namespace Clinic.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMedOfficeRepository _medOfficeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMedAreaRepository _medAreaRepository;

        public AppointmentService(IAppointmentRepository appointmentrepository,
                    IMedOfficeRepository medOfficeRepository,
                    IUserRepository userRepository,
                    IMedAreaRepository medAreaRepository)
        {
            _appointmentRepository = appointmentrepository;
            _medOfficeRepository = medOfficeRepository;
            _userRepository = userRepository;
            _medAreaRepository = medAreaRepository;
        }
        async public Task AddAppointment(AddAppointmentDto appointment)
        {
            //var medOffice = await _medOfficeRepository.GetById(appointment.MedOfficeId);
            //SPRAWDZENIE medOffice
           // var doctor = await _userRepository.GetById(appointment.DoctorId);
            //doctor.ifUserNotExists("Error with selected doctor");
            //var medArea = DOKOŃCZYĆ

            //sprawdzić, czy w tych godzinach gabinet i lekarz są wolni
            List<Appointment> appointments = new List<Appointment>();

            

            appointment.Dates.ForEach(date =>
            {
                var startDate = date.AddHours(appointment.StartHour)
                                    .AddMinutes(appointment.StartMinute);
                var endDate = date.AddHours(appointment.EndHour)
                                  .AddMinutes(appointment.EndMinute);
                for(DateTime tempDate= startDate; tempDate <= endDate; tempDate=tempDate.AddMinutes(appointment.RangeInMinutes))
                {
                    //  tempAppointment.Doctor = (Doctor)doctor;
                    // tempAppointment.MedOffice = medOffice;

                    appointments.Add(new Appointment
                    {
                        Id = Guid.NewGuid(),
                        Date = tempDate,
                    }); ; 

                }
    
            });

        }

        public Task DeleteAppointment(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetWithFilter(AppointmentFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAppointment(AddAppointmentDto appointment)
        {
            throw new NotImplementedException();
        }
    }
}
