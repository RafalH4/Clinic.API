using Clinic.API.Data;
using Clinic.API.IRepositories;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly DataContext _context;
        public ContractRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contract>> Get()
            => await Task.FromResult(_context.Contracts.ToList());

        public async Task<IEnumerable<Contract>> GetByDepartment(Department department)
            => await Task.FromResult(_context.Contracts
                .Where(contract => contract.Department.Equals(department)).ToList());


        public async Task<IEnumerable<Contract>> GetByDoctor(Doctor doctor)
            => await Task.FromResult(_context.Contracts
                .Where(contract => contract.Doctor.Equals(doctor)).ToList());

        public async Task<IEnumerable<Contract>> GetByMedArea(MedArea medArea)
            => await Task.FromResult(_context.Contracts
                .Where(contract => contract.MedArea.Equals(medArea)).ToList());

        public async Task<Contract> GetByDoctorAndDepartment(Doctor doctor, Department department)
            => await Task.FromResult(_context.Contracts
            .Where(contract => contract.Department.Equals(department))
            .Where(contract => contract.Doctor.Equals(doctor)).FirstOrDefault());

        public async Task AddContract(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteContract(Contract contract)
        {
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateContract(Contract contract)
        {
            _context.Contracts.Update(contract);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
