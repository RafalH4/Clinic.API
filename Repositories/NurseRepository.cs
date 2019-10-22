using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly DataContext _context;
        public NurseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddNurse(Nurse nurse)
        {
            await _context.Nurses.AddAsync(nurse);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteNurse(Nurse nurse)
        {
            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Nurse>> Get()
        {
            var nurses = _context.Nurses.ToList();
            return await Task.FromResult(nurses);
        }

        public async Task<Nurse> GetByEmail(string email)
            => await Task.FromResult(_context.Nurses.SingleOrDefault(
                nurse => nurse.Email == email));

        public async Task<Nurse> GetById(Guid id)
            => await Task.FromResult(_context.Nurses.SingleOrDefault(
                nurse => nurse.Id == id));

        public async Task<Nurse> GetByPesel(string pesel)
            => await Task.FromResult(_context.Nurses.SingleOrDefault(
                nurse => nurse.Pesel == pesel));

        public async Task UpdateNurse(Nurse nurse)
        {
            _context.Nurses.Update(nurse);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
