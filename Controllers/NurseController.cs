using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.API.DTOs;
using Clinic.API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NurseController : Controller
    {
        private readonly INurseService _nurseService;

        public NurseController(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NurseDto>>> Get()
        {
            var doctors = await _nurseService.GetAll();
            return Json(doctors);
        }

        [HttpGet("/id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var nurse = await _nurseService.GetById(id);
            return Json(nurse);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var nurse = await _nurseService.GetByEmail(email);
            return Json(nurse);
        }

        [HttpGet("pesel/{pesel}")]
        public async Task<IActionResult> GetByPesel(string pesel)
        {
            var nurse = await _nurseService.GetByPesel(pesel);
            return Json(nurse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NurseDto nurse)
        {
            await _nurseService.AddNurse(nurse.Email, nurse.Password, nurse.Pesel,
                nurse.FirstName, nurse.SecondName, nurse.PhoneNumber, nurse.PostCode,
                nurse.City, nurse.Street, nurse.HouseNumber);
            return Created("/nurses/", null);
        }

        [HttpDelete("{nurseId}")]
        public async Task<IActionResult> DeleteDoctor(Guid nurseId)
        {
            await _nurseService.DeleteNurse(nurseId);
            return NoContent();
        }

        [HttpPut("{nurseId}")]
        public async Task<IActionResult> UpdateDoctor(Guid nurseId, [FromBody]NurseDto nurse)
        {
            await _nurseService.UpdateNurse(nurseId, nurse.Street, nurse.PostCode,
                nurse.PhoneNumber, nurse.City);

            return NoContent();
        }
    }
}