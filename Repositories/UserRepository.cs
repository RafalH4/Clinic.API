using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> Get()
            => await Task.FromResult(_context.Users.ToList());

        public async Task<User> GetByEmail(string email)
            => await Task.FromResult(_context.Users.SingleOrDefault(
                user => user.Email == email));

        public async Task<User> GetById(Guid id)
            => await Task.FromResult(_context.Users.SingleOrDefault(
                user => user.Id == id));

        public async Task<User> GetByPesel(string pesel)
            => await Task.FromResult(_context.Users.SingleOrDefault(
                user => user.Pesel == pesel));

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
