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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorDto doctor)
        {
            await _doctorService.AddDoctor(doctor.Email, doctor.Password, doctor.Pesel,
                doctor.FirstName, doctor.SecondName, doctor.PhoneNumber, doctor.PostCode,
                doctor.City, doctor.Street, doctor.HouseNumber);
            return Created("/doctors/5", null);
        }

    }
}