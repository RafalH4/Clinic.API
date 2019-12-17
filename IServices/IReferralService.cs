using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IReferralService
    {
        Task<IEnumerable<Referral>> GetAll();
        Task<IEnumerable<Referral>> GetWithFilters();
        Task<Referral> GetById();
        Task AddReferral(AddReferralDto referralDto, Guid appointmentId);
        Task<IEnumerable<ReferralDto>> GetByAppointmentId(Guid id);
        Task AddReferral();
        Task UpdateReferral();
        Task DeleteReferral();
    }
}
