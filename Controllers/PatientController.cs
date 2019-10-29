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
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> Get()
        {
            var patients = await _patientService.GetAll();
            return Json(patients);
        }

        [HttpGet("/id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var patient = await _patientService.GetById(id);
            return Json(patient);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var patient = await _patientService.GetByEmail(email);
            return Json(patient);
        }

        [HttpGet("pesel/{pesel}")]
        public async Task<IActionResult> GetByPesel(string pesel)
        {
            var patient = await _patientService.GetByPesel(pesel);
            return Json(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientDto patient)
        {
            await _patientService.AddPatient(patient.Email, patient.Password, patient.Pesel,
                patient.FirstName, patient.SecondName, patient.PhoneNumber, patient.PostCode,
                patient.City, patient.Street, patient.HouseNumber);
            return Created("/patients", null);
        }

        [HttpDelete("{patientId}")]
        public async Task<IActionResult> DeletePatient(Guid patientId)
        {
            await _patientService.DeletePatient(patientId);
            return NoContent();
        }

        [HttpPut("{patientId}")]
        public async Task<IActionResult> UpdatePatient(Guid patientId, [FromBody]PatientDto patient)
        {
            await _patientService.UpdatePatient(patientId, patient.Street, patient.PostCode,
                patient.PhoneNumber, patient.City);

            return NoContent();
        }

    }
}