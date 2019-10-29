using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.API.DTOs;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using Clinic.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> Get()
        {
            var doctors = await _doctorService.GetAll();
            return Json(doctors);
        }
        
        [HttpGet("/id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var doctor = await _doctorService.GetById(id);
            return Json(doctor);
        }
        
        [HttpGet("email/{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var doctor = await _doctorService.GetByEmail(email);
            return Json(doctor);
        }
        
        [HttpGet("pesel/{pesel}")]
        public async Task<IActionResult> GetByPesel(string pesel)
        {
            var doctor = await _doctorService.GetByPesel(pesel);
            return Json(doctor);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorDto doctor)
        {
            await _doctorService.AddDoctor(doctor.Email, doctor.Password, doctor.Pesel,
                doctor.FirstName, doctor.SecondName, doctor.PhoneNumber, doctor.PostCode,
                doctor.City, doctor.Street, doctor.HouseNumber);
            return Created("/doctors/5", null);
        }
       
        [HttpDelete("{doctorId}")]
        public async Task<IActionResult> DeleteDoctor (Guid doctorId)
        {
            await _doctorService.DeleteDoctor(doctorId);
            return NoContent();
        }
        
        [HttpPut("{doctorId}")]
        public async Task<IActionResult> UpdateDoctor(Guid doctorId, [FromBody]DoctorDto doctor)
        {
            await _doctorService.UpdateDoctor(doctorId, doctor.Street, doctor.PostCode, 
                doctor.PhoneNumber, doctor.City);

            return NoContent();
        }


    }
}