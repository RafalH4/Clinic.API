using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class RootRepository : IRootRepository
    {
        private readonly DataContext _context;
        public RootRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddRoot(Root root)
        {
            await _context.Roots.AddAsync(root);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteRoot(Root root)
        {
            _context.Roots.Remove(root);
            await _context.SaveChangesAsync();
            await Task.CompletedTask; 
        }

        public async Task<IEnumerable<Root>> Get()
        {
            var roots = _context.Roots.ToList();
            return await Task.FromResult(roots);
        }

        public async Task<Root> GetByEmail(string email)
            => await Task.FromResult(_context.Roots.SingleOrDefault(root => root.Email == email));

        public async Task<Root> GetById(Guid id)
            => await Task.FromResult(_context.Roots.SingleOrDefault(root => root.Id == id));

        public async Task<Root> GetByPesel(string pesel)
            => await Task.FromResult(_context.Roots.SingleOrDefault(root => root.Pesel == pesel));

        public async Task UpdateRoot(Root root)
        {
            _context.Roots.Update(root);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
