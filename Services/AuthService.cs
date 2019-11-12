using Clinic.API.Extensions;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
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
        private readonly IJwtHandler _jwtHandler;
        public AuthService(IUserRepository userRepository, 
            IPatientRepository patientRepository, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _patientRepository = patientRepository;
            _jwtHandler = jwtHandler;
        }
        public async Task<string> Login(string userName, string password)
        {
            var user = await _patientRepository.GetByEmail(userName);
            user.ifUserNotExists("This email is existed in db");
            if (!user.checkPassword(password))
                throw new Exception("Insert correct password");

            var token = _jwtHandler.CreateToken(user);
            return token;

        }

        public async Task Register(string email, string password, string firstName, 
            string secondName, string pesel, string phoneNumber, string postCode, 
            string city, string street, string houseNumber)
        {
            var user = await _userRepository.GetByEmail(email);
            user.ifUserExists("This email is existed in db");

            user = await _userRepository.GetByPesel(pesel);
            user.ifUserExists("This pesel is existed in db");

            var patientToCreate = new Patient(Guid.NewGuid(), email, "patient", DateTime.UtcNow,
                firstName, secondName, pesel, phoneNumber, postCode, city, street, houseNumber);

            var hmac = new System.Security.Cryptography.HMACSHA512();
            patientToCreate.PasswordSalt = hmac.Key;
            patientToCreate.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            await _patientRepository.AddPatient(patientToCreate);
        }
    }
}
