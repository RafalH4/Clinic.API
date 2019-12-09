﻿using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class UsersMapper
    {
        public static DoctorDetailDto mapToDoctorDetailDto(this Doctor doctor, List<Contract> contracts)
        {
            var newDoctor = new DoctorDetailDto();
            newDoctor.Id = doctor.Id;
            newDoctor.Pesel = doctor.Pesel;
            newDoctor.PhoneNumber = doctor.PhoneNumber;
            newDoctor.HouseNumber = doctor.HouseNumber;
            newDoctor.PostCode = doctor.PostCode;
            newDoctor.Role = doctor.Role;
            newDoctor.Street = doctor.Street;
            newDoctor.FirstName = doctor.FirstName;
            newDoctor.SecondName = doctor.SecondName;
            newDoctor.Email = doctor.Email;
            newDoctor.City = doctor.City;
            var contractsDto = new List<ContractDto>();
            foreach (var contract in contracts)
            {
                var contr = contract.mapToContractDto();
                contractsDto.Add(contr); 
            }
            newDoctor.Contracts = contractsDto;
            //newDoctor.Appointments= UZUPEŁNIĆ!!!
            return newDoctor;
        }
        public static DoctorDto mapToDoctorDto(this Doctor doctor)
        {
            var newDoctor = new DoctorDto();
            newDoctor.Id = doctor.Id;
            newDoctor.Pesel = doctor.Pesel;
            newDoctor.PhoneNumber = doctor.PhoneNumber;
            newDoctor.HouseNumber = doctor.HouseNumber;
            newDoctor.PostCode = doctor.PostCode;
            newDoctor.Role = doctor.Role;
            newDoctor.Street = doctor.Street;
            newDoctor.FirstName = doctor.FirstName;
            newDoctor.SecondName = doctor.SecondName;
            newDoctor.Email = doctor.Email;
            newDoctor.City = doctor.City;
            return newDoctor;
        }
    }
}
