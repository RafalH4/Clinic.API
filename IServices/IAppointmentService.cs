using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
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
        Task<IEnumerable<AppointmentDto>> GetAll();
        Task<IEnumerable<AppointmentDto>> GetWithFilter(DateTime? startDate,
            DateTime? endDate,
            Guid? doctorId,
            Guid? patientId,
            Guid? medOfficeId,
            bool? isFree);
        Task AddAppointment(AddAppointmentDto appointment);
        Task DeleteAppointment(Guid id);
        Task ModifyAppointment(AddAppointmentDto appointment);
    }
}
