using Clinic.API.DTOs;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAll() 
            => await _userRepository.Get();

        public async Task<User> GetById(Guid id)
            => await _userRepository.GetById(id);

        public async Task<bool> IfEmailAvaiable(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
                return true;
            return false;
        }

        public async Task UpdateUser(UserDto user)
        {
            var tempUser = await _userRepository.GetById(user.Id);
            if (tempUser == null)
                throw new Exception("Bad ID");

            tempUser.FirstName = user.FirstName;
            tempUser.SecondName = user.SecondName;
            tempUser.Pesel = user.Pesel;
            tempUser.Email = user.Email;
            tempUser.PostCode = user.PostCode;
            tempUser.City = user.City;
            tempUser.Street = user.Street;
            tempUser.HouseNumber = user.HouseNumber;
            tempUser.PhoneNumber = user.PhoneNumber;




            await _userRepository.UpdateUser(tempUser);

        }
    }
}
