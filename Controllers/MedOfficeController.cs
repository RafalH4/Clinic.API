﻿using System;
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
    public class MedOfficeController : Controller
    {
        private readonly IMedOfficeService _medOfficeService;
        public MedOfficeController(IMedOfficeService medOfficeService)
        {
            _medOfficeService = medOfficeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedOffice>>> Get()
        {
            var medOffices = await _medOfficeService.GetAll();
            return Json(medOffices);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMedOfficeDto medOffice)
        {
            await _medOfficeService.AddMedOffice(medOffice);
            return Created("/medOffice", null);
        }
    }
}