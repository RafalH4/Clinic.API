using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class DoctorService :IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> GetAsync()
        {
            Guid id = new Guid("53750992-4bc2-421d-5394-08d7522f1f2c");
            var doctor = await _doctorRepository.Get(id);
            return doctor;
        }
    }
}
