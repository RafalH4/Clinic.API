using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class ContractMapper
    {
        public static Contract mapToContract(this AddContractDto contractDto, Department department, Doctor doctor)
        {
            var contract = new Contract();
            contract.Id = Guid.NewGuid();
            contract.HoursPerMonth = contractDto.HoursPerMonth;
            contract.NumberOfMonths = contractDto.NumberOfMonths;
            contract.SalaryPerMonth = contractDto.SalaryPerMonth;
            contract.SignedAt = contractDto.StartDate;
            contract.Department = department;
            contract.Doctor = doctor;

            return contract;
        }

        public static ContractDto mapToContractDto(this Contract contract)
        {
            var contractDto = new ContractDto();
            contractDto.Id = contract.Id;
            contractDto.SignedAt = contract.SignedAt;
            contractDto.NumberOfMonths = contract.NumberOfMonths;
            contractDto.HoursPerMonth = contract.HoursPerMonth;
            contractDto.SalaryPerMonth = contract.SalaryPerMonth;

            return contractDto;
        }

        public static ContractDetailsDto mapToContractDetailsDto(this Contract contract)
        {
            var contractDetailsDto = new ContractDetailsDto();
            contractDetailsDto.Id = contract.Id;
            contractDetailsDto.SignedAt = contract.SignedAt;
            contractDetailsDto.NumberOfMonths = contract.NumberOfMonths;
            contractDetailsDto.HoursPerMonth = contract.HoursPerMonth;
            contractDetailsDto.SalaryPerMonth = contract.SalaryPerMonth;
            contractDetailsDto.Doctor = contract.Doctor.mapToDoctorDto();
            contractDetailsDto.Department = contract.Department.mapToDepartmentDto();

            return contractDetailsDto;
        }
    }
}
