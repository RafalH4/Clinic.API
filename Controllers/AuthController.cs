using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Clinic.API.DTOs;
using Clinic.API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Clinic.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userFroRegisterDto)
        { 
            await _authService.Register(userFroRegisterDto.Email, userFroRegisterDto.Password,
                userFroRegisterDto.FirstName, userFroRegisterDto.SecondName, userFroRegisterDto.Pesel,
                userFroRegisterDto.PhoneNumber, userFroRegisterDto.PostCode, userFroRegisterDto.City,
                userFroRegisterDto.Street, userFroRegisterDto.HouseNumber);
            
            return StatusCode(201);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userFromLoginDto)
        {
            var token = await _authService.Login(userFromLoginDto.UserName, userFromLoginDto.Password);
            return Ok(new
            {
                token = token
            });
        }



    }
}