using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.API.DTOs;
using Clinic.API.IServices;
using Clinic.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users = await _userService.GetAll();
            return Json(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(Guid id)
            => await _userService.GetById(id);

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] UserDto user)
        {
            await _userService.UpdateUser(user);
            return NoContent();
        }
    }
}