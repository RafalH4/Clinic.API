using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {

            return Json(null);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            doctor.Id = Guid.NewGuid();
            await _doctorService.AddDoctor(doctor.Email, doctor.Password, doctor.Pesel,
                doctor.FirstName, doctor.SecondName, doctor.PhoneNumber, doctor.PostCode,
                doctor.City, doctor.Street, doctor.HouseNumber);
            return Created("/doctors/5", null);
        }

    }
}