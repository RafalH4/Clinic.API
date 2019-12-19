using Clinic.API.DTOs;
using Clinic.API.Extensions;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using Clinic.API.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly INurseRepository _nurseRepository;
        private readonly IRootRepository _rootRepository;
        private readonly IJwtHandler _jwtHandler;
        public AuthService(IUserRepository userRepository, 
            IPatientRepository patientRepository, IDoctorRepository doctorRepository,
            INurseRepository nurseRepository, IRootRepository rootRepository,
            IJwtHandler jwtHandler)
        {
            _rootRepository = rootRepository;
            _doctorRepository = doctorRepository;
            _nurseRepository = nurseRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
            _jwtHandler = jwtHandler;
        }
        public async Task<string> Login(string userName, string password)
        {
            var user = await _userRepository.GetByEmail(userName);
            user.ifUserNotExists("This email is existed in db");
            if (!user.checkPassword(password))
                throw new Exception("Insert correct password");

            var token = _jwtHandler.CreateToken(user);
            return token;

        }

        public async Task Register(UserForRegisterDto userForRegisterDto)
        {
            var user = await _userRepository.GetByEmail(userForRegisterDto.Email);
            user.ifUserExists("This email is existed in db");

            user = await _userRepository.GetByPesel(userForRegisterDto.Pesel);
            user.ifUserExists("This pesel is existed in db");

            var hmac = new System.Security.Cryptography.HMACSHA512();

            if (userForRegisterDto.Role=="root")
            {
                var root = new Root(Guid.NewGuid(), userForRegisterDto.Email, userForRegisterDto.Role,
                    DateTime.UtcNow, userForRegisterDto.FirstName, userForRegisterDto.SecondName,
                    userForRegisterDto.Pesel, userForRegisterDto.PhoneNumber, userForRegisterDto.PostCode,
                    userForRegisterDto.City, userForRegisterDto.Street, userForRegisterDto.HouseNumber);

                root.PasswordSalt = hmac.Key;
                root.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userForRegisterDto.Password));
                EmailSender.SendEmail(userForRegisterDto.Email, "Witaj nowy użytkowniku", "Zapraszamy do korzystania z aplikacji");
                await _rootRepository.AddRoot(root);

            } else if(userForRegisterDto.Role == "doctor")
            {
                var doctor = new Doctor(Guid.NewGuid(), userForRegisterDto.Email, userForRegisterDto.Role,
                    DateTime.UtcNow, userForRegisterDto.FirstName, userForRegisterDto.SecondName,
                    userForRegisterDto.Pesel, userForRegisterDto.PhoneNumber, userForRegisterDto.PostCode,
                    userForRegisterDto.City, userForRegisterDto.Street, userForRegisterDto.HouseNumber);

                doctor.PasswordSalt = hmac.Key;
                doctor.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userForRegisterDto.Password));
                EmailSender.SendEmail(userForRegisterDto.Email, "Witaj nowy użytkowniku", "Zapraszamy do korzystania z aplikacji");
                await _doctorRepository.AddDoctor(doctor);

            } else if(userForRegisterDto.Role == "nurse")
            {
                var nurse = new Nurse(Guid.NewGuid(), userForRegisterDto.Email, userForRegisterDto.Role,
                    DateTime.UtcNow, userForRegisterDto.FirstName, userForRegisterDto.SecondName,
                    userForRegisterDto.Pesel, userForRegisterDto.PhoneNumber, userForRegisterDto.PostCode,
                    userForRegisterDto.City, userForRegisterDto.Street, userForRegisterDto.HouseNumber);

                nurse.PasswordSalt = hmac.Key;
                nurse.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userForRegisterDto.Password));
                EmailSender.SendEmail(userForRegisterDto.Email, "Witaj nowy użytkowniku", "Zapraszamy do korzystania z aplikacji");
                await _nurseRepository.AddNurse(nurse);

            } else if (userForRegisterDto.Role == "patient")
            {
                var patient = new Patient(Guid.NewGuid(), userForRegisterDto.Email, userForRegisterDto.Role,
                    DateTime.UtcNow, userForRegisterDto.FirstName, userForRegisterDto.SecondName,
                    userForRegisterDto.Pesel, userForRegisterDto.PhoneNumber, userForRegisterDto.PostCode,
                    userForRegisterDto.City, userForRegisterDto.Street, userForRegisterDto.HouseNumber);

                patient.PasswordSalt = hmac.Key;
                patient.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userForRegisterDto.Password));
                EmailSender.SendEmail(userForRegisterDto.Email, "Witaj nowy użytkowniku", "Zapraszamy do korzystania z aplikacji");
                await _patientRepository.AddPatient(patient);
            }
        }
    }
}
