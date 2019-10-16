using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext _context;
        public DoctorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Doctor> Get(Guid id)
        {
            Doctor doctor = new Doctor();
            doctor = _context.Doctors.SingleOrDefault(x => x.Id == id);
            return await Task.FromResult(doctor);
        }

    }
}
