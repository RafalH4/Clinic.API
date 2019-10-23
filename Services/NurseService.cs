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
        public NurseService(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }
        public async Task AddNurse(string email, string password, string pesel, 
            string firstName, string secondName, string phoneNumber, 
            string postCode, string city, string street, string houseNumber)
        {
            var nurse = await _nurseRepository.GetByEmail(email);
            nurse.ifUserExists("This email is existed in db");

            nurse = await _nurseRepository.GetByPesel(pesel);
            nurse.ifUserExists("This pesel is existed in db");

            nurse = new Nurse(new Guid(), email, password, "nurse",
                DateTime.UtcNow, firstName, secondName, pesel, phoneNumber,
                postCode, city, street, houseNumber);

            await _nurseRepository.AddNurse(nurse);
        }

        public Task DeleteNurse(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Nurse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Nurse> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Nurse> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Nurse> GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNurse(Guid id, string street, string postCode, string phoneNumber, string city)
        {
            throw new NotImplementedException();
        }
    }
}
