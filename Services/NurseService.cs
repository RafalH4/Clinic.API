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
    public class NurseService : INurseService
    {
        private readonly INurseRepository _nurseRepository;
        private readonly IUserRepository _userRepository;
        public NurseService(INurseRepository nurseRepository, IUserRepository userRepository)
        {
            _nurseRepository = nurseRepository;
            _userRepository = userRepository;
        }
        public async Task AddNurse(string email, string password, string pesel, 
            string firstName, string secondName, string phoneNumber, 
            string postCode, string city, string street, string houseNumber)
        {
            var user = await _nurseRepository.GetByEmail(email);
            user.ifUserExists("This email is existed in db");

            user = await _nurseRepository.GetByPesel(pesel);
            user.ifUserExists("This pesel is existed in db");

           var nurse = new Nurse(new Guid(), email, "nurse",
                DateTime.UtcNow, firstName, secondName, pesel, phoneNumber,
                postCode, city, street, houseNumber);

            await _nurseRepository.AddNurse(nurse);
        }

        public async Task DeleteNurse(Guid id)
        {
            var nurse = await _nurseRepository.GetById(id);
            nurse.ifUserNotExists("Db doesn't contain this doctor");

            await _nurseRepository.DeleteNurse(nurse);
        }

        public async Task<IEnumerable<Nurse>> GetAll()
            => await _nurseRepository.Get();

        public async Task<Nurse> GetByEmail(string email)
            => await _nurseRepository.GetByEmail(email);

        public async Task<Nurse> GetById(Guid id)
            => await _nurseRepository.GetById(id);

        public async Task<Nurse> GetByPesel(string pesel)
            => await _nurseRepository.GetByPesel(pesel);

        public async Task UpdateNurse(Guid id, string street, string postCode, string phoneNumber, string city)
        {
            var nurse = await _nurseRepository.GetById(id);
            nurse.ifUserNotExists("Db doesn't contain this doctor");

            nurse.Street = street;
            nurse.PostCode = postCode;
            nurse.PhoneNumber = phoneNumber;
            nurse.City = city;

            await _nurseRepository.UpdateNurse(nurse);
        }
    }
}
