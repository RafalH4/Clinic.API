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
    public class ReferralController : Controller
    {
        private readonly IReferralService _referralService;
        public ReferralController(IReferralService referralService)
        {
            _referralService = referralService;

        }
        [HttpPost("{appointmentId}")]
        public async Task<IActionResult> Post([FromBody] AddReferralDto referral, Guid appointmentId)
        {
            await _referralService.AddReferral(referral, appointmentId);
            return Created("/doctors/5", null);
        }

        [HttpGet("{appointmentId}")]
        public async Task<IActionResult> GetByAppointmentId(Guid appointmentId)
        {
            var prescriptions = await _referralService.GetByAppointmentId(appointmentId);
            return Json(prescriptions);
        }
    }
}