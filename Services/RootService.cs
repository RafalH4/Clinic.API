using Clinic.API.Extensions;
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
        public async Task AddRoot(string email, string password, string pesel, 
            string firstName, string secondName, string phoneNumber, 
            string postCode, string city, string street, string houseNumber)
        {
            var user = await _rootRepository.GetByEmail(email);
            user.ifUserExists("This email is existed in db");

            user = await _rootRepository.GetByPesel(pesel);
            user.ifUserExists("This pesel is existed in db");

            var root = new Root(new Guid(), email, password, "root",
                 DateTime.UtcNow, firstName, secondName, pesel, phoneNumber,
                 postCode, city, street, houseNumber);

            await _rootRepository.AddRoot(root);
        }

        public async Task DeleteRoot(Guid id)
        {
            var root = await _rootRepository.GetById(id);
            root.ifUserNotExists("Db doesn't contain this doctor");

            await _rootRepository.DeleteRoot(root);
        }

        public async Task<IEnumerable<Root>> GetAll()
            => await _rootRepository.Get();

        public async Task<Root> GetByEmail(string email)
            => await _rootRepository.GetByEmail(email);

        public async Task<Root> GetById(Guid id)
            => await _rootRepository.GetById(id);

        public async Task<Root> GetByPesel(string pesel)
            => await _rootRepository.GetByPesel(pesel);

        public async Task UpdateRoot(Guid id, string street, string postCode, string phoneNumber, string city)
        {
            var root = await _rootRepository.GetById(id);
            root.ifUserNotExists("Db doesn't contain this doctor");

            root.Street = street;
            root.PostCode = postCode;
            root.PhoneNumber = phoneNumber;
            root.City = city;

            await _rootRepository.UpdateRoot(root);
        }
    }
}
