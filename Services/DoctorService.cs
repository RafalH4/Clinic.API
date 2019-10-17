using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task AddDoctor(string email, string password, 
            string pesel, string firstName, string secondName, 
            string phoneNumber, string postCode, string city, 
            string street, string houseNumber)
        {
            var doctor = await _doctorRepository.GetByEmail(email);
            if(doctor != null)
            {
                throw new Exception("This email is existed in db");
            }
            doctor = await _doctorRepository.GetByPesel(pesel);
            if(doctor != null)
            {
                throw new Exception("This pesel is existed in db");
            }

            doctor = new Doctor(new Guid(), email, password, "doctor", 
                DateTime.UtcNow, firstName, secondName, pesel, phoneNumber,
                postCode, city, street, houseNumber);

            await _doctorRepository.AddDoctor(doctor);
        }

        public async Task DeleteDoctor(Guid id)
        {
            var doctor = await _doctorRepository.GetById(id); 
            if(doctor == null)
            {
                throw new Exception("Db doesn't contain this doctor");
            }
            await _doctorRepository.DeleteDoctor(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            var doctors = await _doctorRepository.Get();
            return doctors;
        }

        public async Task<Doctor> GetByEmail(string email)
        {
            var doctor = await _doctorRepository.GetByEmail(email);
            if(doctor == null)
            {
                throw new Exception("Db doesn't contain this doctor");
            }
            return doctor;
        }

        public async Task<Doctor> GetById(Guid id)
        {
            var doctor = await _doctorRepository.GetById(id);
            if (doctor == null)
            {
                throw new Exception("Db doesn't contain this doctor");
            }
            return doctor;
        }

        public Task<Doctor> GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Doctor>> GetByMedArea(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doctor>> GetByMedOffice(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doctor>> GetByPatient(Guid pesel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctor(Guid id, string email, string password, 
            string firstName, string secondName, string phoneNumber, 
            string postCode, string city, string street, string houseNumber)
        {
            throw new NotImplementedException();
        }
    }
}
