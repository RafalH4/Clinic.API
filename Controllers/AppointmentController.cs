using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Clinic.API.DTOs;
using Clinic.API.DTOs.Add;
using Clinic.API.Filters;
using Clinic.API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]DateTime? startDate,
            [FromQuery]DateTime? endDate,
            [FromQuery]Guid? doctorId,
            [FromQuery]Guid? patientId,
            [FromQuery]Guid? medOfficeId,
            [FromQuery]string? departmentName,
            [FromQuery]bool? isFree)
        {
            var appointments = await _appointmentService.GetWithFilter(startDate, endDate, doctorId, patientId, medOfficeId, departmentName, isFree);

            return Json(appointments);
        }
        [HttpPost("addUser")]
        public async Task<IActionResult> Post([FromBody] AddUserToAppointmentDto assigment)
        {
            await _appointmentService.AddPatientToAppointment(assigment);
            return Created("/appointment", null);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAppointmentDto appointment)
        {           
            await _appointmentService.AddAppointment(appointment);
            return Created("/appointment", null);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _appointmentService.DeleteAppointment(id);
            return NoContent();
        }


    }
}