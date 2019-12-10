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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> Get()
            => await Task.FromResult(_context.Departments
                                .Include(x => x.Contracts)
                                .Include(x => x.MedOffices)
                                .ToList());

        public async Task<Department> GetById(Guid id)
            => await Task.FromResult(_context.Departments
                                .Include(x => x.Contracts)
                                .Include(x => x.MedOffices)
                .SingleOrDefault(department => department.Id == id));

        public async Task<Department> GetByMedOffice(MedOffice medOffice)
            => await Task.FromResult(_context.Departments
                                .Include(x => x.Contracts)
                                .Include(x => x.MedOffices)
                .SingleOrDefault(department => department.MedOffices.Equals(medOffice)));

        public async Task<Department> GetByName(string name)
            => await Task.FromResult(_context.Departments
                                .Include(x => x.Contracts)
                                .Include(x => x.MedOffices)
                .SingleOrDefault(department => department.Name == name));
        public async Task AddDepartment(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }


    }
}
