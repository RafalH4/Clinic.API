using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
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
            var doctor = await _doctorService.GetAsync();
            return Json(doctor);
        }

    }
}