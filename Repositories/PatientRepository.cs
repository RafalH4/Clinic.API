using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class PatientRepository :IPatientRepository
    {
        private readonly DataContext _context;
        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddPatient(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            await Task.CompletedTask; 
        }

        public async Task<IEnumerable<Patient>> Get()
        {
            var patients = _context.Patients.ToList();
            return await Task.FromResult(patients);
        }

        public async Task<Patient> GetByEmail(string email)
            => await Task.FromResult(_context.Patients.SingleOrDefault(
                patient => patient.Email == email));

        public async Task<Patient> GetById(Guid id)
            => await Task.FromResult(_context.Patients.SingleOrDefault(
                patient => patient.Id == id));

        public async Task<Patient> GetByPesel(string pesel)
            => await Task.FromResult(_context.Patients.SingleOrDefault(
                patient => patient.Pesel == pesel));

        public async Task UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
