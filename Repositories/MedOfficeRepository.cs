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
    public class MedOfficeRepository : IMedOfficeRepository
    {
        private readonly DataContext _context;
        public MedOfficeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MedOffice>> Get()
        {
            var medOffice = await Task.FromResult(_context.MedOffices.Include(x => x.Department).ToList());
            return medOffice;
        }
         //   => await Task.FromResult(_context.MedOffices.ToList());

        public async Task<IEnumerable<MedOffice>> GetByDepartment(Department department)
            => await Task.FromResult(_context.MedOffices
                .Where(medOffice => medOffice.Department.Equals(department)).ToList());

        public async Task<MedOffice> GetById(Guid id)
            => await Task.FromResult(_context.MedOffices
                .SingleOrDefault(medOffice => medOffice.Id == id));

        public async Task<MedOffice> GetByOfficeNumberAndDepartmentId(int number, string departmentName)
            => await Task.FromResult(_context.MedOffices
                .Where(office => office.OfficeNumber == number && office.Department.Name == departmentName)
                .FirstOrDefault());


        public async Task AddMedOffice(MedOffice medOffice)
        {
            await _context.MedOffices.AddAsync(medOffice);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteMedOffice(MedOffice medOffice)
        {
            _context.MedOffices.Remove(medOffice);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateMedOffice(MedOffice medOffice)
        {
            _context.MedOffices.Update(medOffice);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }


    }
}
