using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.DTOs.Mappers;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public ContractService(IContractRepository contractRepository,
                               IDoctorRepository doctorRepository,
                               IDepartmentRepository departmentRepository)
        {
            _contractRepository = contractRepository;
            _doctorRepository = doctorRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task AddContract(AddContractDto contract)
        {
            var doctor = await _doctorRepository.GetById(contract.DoctorId);
            var department = await _departmentRepository.GetById(contract.DepartmentId);
            var testContract = await _contractRepository.GetByDoctorAndDepartment(doctor, department);
            if (testContract != null )
            {
                if (testContract.SignedAt.AddMonths(contract.NumberOfMonths) < contract.StartDate)
                    throw new Exception("This doctor has contract in this date range");
            }

            var newContract = contract.mapToContract(department, doctor);
            await _contractRepository.AddContract(newContract);
        }

        public Task DeleteContract(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContractDetailsDto>> GetAll()
        {
            var contracts = await _contractRepository.Get();
            var contractsToReturn = new List<ContractDetailsDto>();
            foreach (var contract in contracts)
                contractsToReturn.Add(contract.mapToContractDetailsDto());
            return contractsToReturn;
        }

        public async Task<IEnumerable<ContractDetailsDto>> GetByDeparamentId(Guid id)
        {
            var contracts = await _contractRepository.GetByDepartment(id);
            var contractsToReturn = new List<ContractDetailsDto>();
            foreach (var contract in contracts)
                contractsToReturn.Add(contract.mapToContractDetailsDto());
            return contractsToReturn;
        }
        public Task ModifyContract(AddContractDto contract)
        {
            throw new NotImplementedException();
        }
    }
}
