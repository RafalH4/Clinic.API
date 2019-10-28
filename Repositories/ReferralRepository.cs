using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly DataContext _context;
        public ReferralRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Referral>> Get()
            => await Task.FromResult(_context.Referrals.ToList());

        public async Task<IEnumerable<Referral>> GetByAppointment(Appointment appointment)
            => await Task.FromResult(_context.Referrals
                .Where(referral => referral.Appointment.Equals(appointment)).ToList());

        public async Task<IEnumerable<Referral>> GetByDate(DateTime date)
            => await Task.FromResult(_context.Referrals
                .Where(referral => referral.CreatedAt.Equals(date)).ToList());

        public async Task<Referral> GetById(Guid id)
            => await Task.FromResult(_context.Referrals
                .SingleOrDefault(referral => referral.Id.Equals(id)));
        public async Task AddReferral(Referral referral)
        {
            await _context.Referrals.AddAsync(referral);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteReferral(Referral referral)
        {
            _context.Referrals.Remove(referral);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateReferral(Referral referral)
        {
            _context.Referrals.Update(referral);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
