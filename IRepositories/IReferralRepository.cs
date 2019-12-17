using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IReferralRepository
    {
        Task<IEnumerable<Referral>> Get();
        Task<IEnumerable<Referral>> GetByAppointment(Appointment appointment);
        Task<IEnumerable<Referral>> GetByPatient (Patient patient);
        Task<IEnumerable<Referral>> GetByDate(DateTime date);
        Task<Referral> GetById(Guid id);
        Task AddReferral(Referral referral);
        Task DeleteReferral(Referral referral);
        Task UpdateReferral(Referral referral);

    }
}
