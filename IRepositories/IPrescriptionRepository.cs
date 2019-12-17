using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> Get();
        Task<IEnumerable<Prescription>> GetByAppointment(Appointment appointment);
        Task<IEnumerable<Prescription>> GetByDate(DateTime date);
        Task<IEnumerable<Prescription>> GetByPatient(Patient patient);
        Task<Prescription> GetById(Guid id);
        Task AddPrescription(Prescription prescription);
        Task DeletePrescription(Prescription prescription);
        Task UpdatePrescription(Prescription prescription);
    }
}
