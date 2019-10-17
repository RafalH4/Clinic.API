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

        public async Task AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            await Task.CompletedTask;  
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await Task.CompletedTask;
        }

        public async Task<Doctor> GetById(Guid id)
        {
            return await Task.FromResult(_context.Doctors.SingleOrDefault(
                doctor => doctor.Id == id));
        }

        public async Task<Doctor> GetByEmail(string email)
        {
            return await Task.FromResult(_context.Doctors.SingleOrDefault(
                doctor => doctor.Email == email));
        }

        public async Task<Doctor> GetByPesel(string pesel)
        {
            return await Task.FromResult(_context.Doctors.SingleOrDefault(
                doctor => doctor.Pesel == pesel));
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await Task.CompletedTask;
        }
    }
}
