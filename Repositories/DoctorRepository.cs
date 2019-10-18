﻿using Clinic.API.Data;
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
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;  
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var doctors = _context.Doctors.ToList();
            return await Task.FromResult(doctors);
        }
        public async Task<Doctor> GetById(Guid id)
            => await Task.FromResult(_context.Doctors.SingleOrDefault(
                doctor => doctor.Id == id));
        

        public async Task<Doctor> GetByEmail(string email)
            => await Task.FromResult(_context.Doctors.SingleOrDefault(
                doctor => doctor.Email == email));
        

        public async Task<Doctor> GetByPesel(string pesel)
            => await Task.FromResult(_context.Doctors.SingleOrDefault(
                doctor => doctor.Pesel == pesel));
        

        public async Task UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

    }
}
