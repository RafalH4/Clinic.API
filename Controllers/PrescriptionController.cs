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
    public class PrescriptionController : Controller 
    {
        private readonly IPrescriptionService _prescriptionService;
        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;

        }
        [HttpPost("{appointmentId}")]
        public async Task<IActionResult> Post([FromBody] AddPrescriptionDto prescription, Guid appointmentId)
        {
            await _prescriptionService.AddPrescription(prescription, appointmentId);
            return Created("/doctors/5", null);
        }
    }
}