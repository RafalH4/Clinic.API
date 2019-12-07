using Clinic.API.DTOs;
using Clinic.API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IAuthService
    {
        Task Register(UserForRegisterDto userForRegisterDto);
        Task<String> Login(string userName, string password);

    }
}
