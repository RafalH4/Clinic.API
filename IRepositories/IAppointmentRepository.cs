using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IAppointmentRepository
    {
       
        Task AddAppointment(Appointment appointment);
        Task AddListAppointments(List<Appointment> appointments);
        Task DeleteAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task<IEnumerable<Appointment>> GetWithFilters(DateTime? startDate,
            DateTime? endDate, Guid? doctorId, Guid? patientId, Guid? medOfficeId, string? departmentName, bool? isFree);
        Task<Appointment> GetById(Guid id);


    }
}
