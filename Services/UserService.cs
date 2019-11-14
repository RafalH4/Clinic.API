using Clinic.API.IRepositories;
using Clinic.API.IServices;
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
        public async Task<bool> IfEmailAvaiable(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
                return true;
            return false;
        }
    }
}
