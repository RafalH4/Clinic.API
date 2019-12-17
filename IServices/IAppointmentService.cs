using Clinic.API.DTOs;
using Clinic.API.DTOs.Add;
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
        Task<AppointmentDto> GetById(Guid id);
        Task<IEnumerable<AppointmentDto>> GetAll();
        Task<IEnumerable<AppointmentDto>> GetByPatientId(Guid id);
        Task<IEnumerable<AppointmentDto>> GetByDoctorId(Guid id);
        Task<IEnumerable<AppointmentDto>> GetWithFilter(DateTime? startDate,
            DateTime? endDate,
            Guid? doctorId,
            Guid? patientId,
            Guid? medOfficeId,
            string? departmentName,
            bool? isFree);

        Task<IEnumerable<AppointmentDto>> GetFreeWithFilter(Guid? doctorId, string? departmentName, DateTime? date);
        Task AddAppointment(AddAppointmentDto appointment);
        Task DeleteAppointment(Guid id);
        Task ModifyAppointment(AddAppointmentDto appointment);
        Task AddPatientToAppointment(AddUserToAppointmentDto assigment);
        Task DeletePatientFromAppointment(Guid AppointmentId, Guid UserId);

    }
}
