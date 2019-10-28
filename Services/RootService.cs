using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class RootService : IRootService
    {
        private readonly IRootRepository _rootRepository;
        private readonly IUserRepository _userRepository;
        public RootService(IRootRepository rootRepository, IUserRepository userRepository)
        {
            _rootRepository = rootRepository;
            _userRepository = userRepository;
        }
        public Task AddRoot(string email, string password, string pesel, 
            string firstName, string secondName, string phoneNumber, 
            string postCode, string city, string street, string houseNumber)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRoot(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Root>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Root> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Root> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Root> GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoot(Guid id, string street, string postCode, string phoneNumber, string city)
        {
            throw new NotImplementedException();
        }
    }
}
