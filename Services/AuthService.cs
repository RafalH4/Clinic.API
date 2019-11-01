using Clinic.API.Extensions;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;
        public AuthService(IAuthRepository authRepository, IUserRepository userRepository, 
            IPatientRepository patientRepository)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }
        public Task Login(string userName, string password)
        {
            throw new NotImplementedException();
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

            byte[] passwordHash;
            byte[] passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            patientToCreate.PasswordHash = passwordHash;
            patientToCreate.PasswordSalt = passwordSalt;

            await _patientRepository.AddPatient(patientToCreate);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passswordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passswordHash[i])
                        return false;
                }
                return true;
            }
        }

    }
}
