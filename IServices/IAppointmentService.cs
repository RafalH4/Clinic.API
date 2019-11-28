using Clinic.API.DTOs;
using Clinic.API.Filters;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task<IEnumerable<Appointment>> GetWithFilter(AppointmentFilter filter);
        Task AddAppointment(AddAppointmentDto appointment);
        Task DeleteAppointment(Guid id);
        Task ModifyAppointment(AddAppointmentDto appointment);
    }
}
