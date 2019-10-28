using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using Clinic.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Clinic.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;

        }

        public async Task AddDoctor(string email, string password, 
            string pesel, string firstName, string secondName, 
            string phoneNumber, string postCode, string city, 
            string street, string houseNumber)
        {
            var user = await _userRepository.GetByEmail(email);
            user.ifUserExists("This email is existed in db");

            user = await _userRepository.GetByPesel(pesel);
            user.ifUserExists("This pesel is existed in db");

            var doctor = new Doctor(new Guid(), email, password, "doctor", 
                DateTime.UtcNow, firstName, secondName, pesel, phoneNumber,
                postCode, city, street, houseNumber);

            await _doctorRepository.AddDoctor(doctor);
        }

        public async Task DeleteDoctor(Guid id)
        {
            var doctor = await _doctorRepository.GetById(id);
            doctor.ifUserNotExists("Db doesn't contain this doctor");

            await _doctorRepository.DeleteDoctor(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetAll()
            =>  await _doctorRepository.Get();
        
        public async Task<Doctor> GetByEmail(string email)
        {
            var doctor = await _doctorRepository.GetByEmail(email);
            doctor.ifUserNotExists("Db doesn't contain this doctor");
            return doctor;
        }

        public async Task<Doctor> GetById(Guid id)
        {
            var doctor = await _doctorRepository.GetById(id);
            doctor.ifUserNotExists("Db doesn't contain this doctor");
            return doctor;
        }

        public async Task<Doctor> GetByPesel(string pesel)
        {
            var doctor = await _doctorRepository.GetByPesel(pesel);
            doctor.ifUserNotExists("Db doesn't contain this doctor");
            return doctor;
        }

        public async Task UpdateDoctor(Guid id, string street, string postCode, 
            string phoneNumber, string city)
        {
            var doctor = await _doctorRepository.GetById(id);
            doctor.ifUserNotExists("Db doesn't contain this doctor");

            doctor.Street = street;
            doctor.PostCode = postCode;
            doctor.PhoneNumber = phoneNumber;
            doctor.City = city;

            await _doctorRepository.UpdateDoctor(doctor);
        }
    }
}
