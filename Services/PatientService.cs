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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        public PatientService(IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }
        public async Task AddPatient(string email, string password, string pesel, 
            string firstName, string secondName, string phoneNumber, 
            string postCode, string city, string street, string houseNumber)
        {
            var user = await _patientRepository.GetByEmail(email);
            user.ifUserExists("This email is existed in db");

            user = await _patientRepository.GetByPesel(pesel);
            user.ifUserExists("This pesel is existed in db");

            var patient = new Patient(new Guid(), email, password, "patient",
                 DateTime.UtcNow, firstName, secondName, pesel, phoneNumber,
                 postCode, city, street, houseNumber);

            await _patientRepository.AddPatient(patient);
        }

        public async Task DeletePatient(Guid id)
        {
            var patient = await _patientRepository.GetById(id);
            patient.ifUserNotExists("Db doesn't contain this doctor");

            await _patientRepository.DeletePatient(patient);
        }

        public async Task<IEnumerable<Patient>> GetAll()
            => await _patientRepository.Get();

        public async Task<Patient> GetByEmail(string email)
            => await _patientRepository.GetByEmail(email);

        public async Task<Patient> GetById(Guid id)
            => await _patientRepository.GetById(id);

        public async Task<Patient> GetByPesel(string pesel)
            => await _patientRepository.GetByPesel(pesel);

        public async Task UpdatePatient(Guid id, string street, string postCode, string phoneNumber, string city)
        {
            var patient = await _patientRepository.GetById(id);
            patient.ifUserNotExists("Db doesn't contain this doctor");

            patient.Street = street;
            patient.PostCode = postCode;
            patient.PhoneNumber = phoneNumber;
            patient.City = city;

            await _patientRepository.UpdatePatient(patient);
        }
    }
}
