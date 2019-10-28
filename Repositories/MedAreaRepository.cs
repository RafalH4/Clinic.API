using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class MedAreaRepository : IMedAreaRepository
    {
        private readonly DataContext _context;
        public MedAreaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedArea>> Get()
            => await Task.FromResult(_context.MedAreas.ToList());
        public async Task AddMedArea(MedArea medArea)
        {
            await _context.MedAreas.AddAsync(medArea);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteArea(MedArea medArea)
        {
            _context.MedAreas.Remove(medArea);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateArea(MedArea medArea)
        {
            _context.MedAreas.Update(medArea);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
