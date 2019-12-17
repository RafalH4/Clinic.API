using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> GetAll();
        Task<IEnumerable<Prescription>> GetWithFilters();
        Task<Prescription> GetById(Guid id);
        Task<IEnumerable<PrescriptionDto>> GetByAppointmentId(Guid id);
        Task<IEnumerable<PrescriptionDto>> GetByPatientId(Guid patientId);
        Task AddPrescription(AddPrescriptionDto prescription, Guid appointmentId);
        Task UpdatePrescription();
        Task DeletePrescription();
    }
}
