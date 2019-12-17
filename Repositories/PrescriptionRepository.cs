using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using Clinic.API.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly DataContext _context;
        public PrescriptionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Prescription>> Get()
            => await Task.FromResult(_context.Prescriptions.ToList());

        public async Task<IEnumerable<Prescription>> GetByAppointment(Appointment appointment)
            => await Task.FromResult(_context.Prescriptions
                .Include(x => x.Appointment)
                .Where(prescription => prescription.Appointment.Equals(appointment)).ToList());

        public async Task<IEnumerable<Prescription>> GetByDate(DateTime date)
            => await Task.FromResult(_context.Prescriptions
                .Where(prescription => prescription.CreatedAt.Equals(date)).ToList());

        public async Task<Prescription> GetById(Guid id)
            => await Task.FromResult(_context.Prescriptions
                .SingleOrDefault(prescription => prescription.Id.Equals(id)));

        public async Task AddPrescription(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
            XMLCreator.CreatePrescription(prescription);
            await Task.CompletedTask;
        }

        public async Task DeletePrescription(Prescription prescription)
        {
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
                
        public async Task UpdatePrescription(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
