using Clinic.API.DTOs;
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
        Task<Prescription> GetById();
        Task AddPrescription(AddPrescriptionDto prescription, Guid appointmentId);
        Task UpdatePrescription();
        Task DeletePrescription();
    }
}
