using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
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
        public async Task<ActionResult<IEnumerable<MedOfficeDetailDto>>> Get()
        {
            var medOffices = await _medOfficeService.GetAll();
            return Json(medOffices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MedOfficeDetailDto>>> GetById(Guid id)
        {
            var medOffices = await _medOfficeService.GetById(id) ;
            return Json(medOffices);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMedOfficeDto medOffice)
        {
            await _medOfficeService.AddMedOffice(medOffice);
            return Created("/medOffice", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AddMedOfficeDto medOffice)
        {
            await _medOfficeService.UpdateMedOffice(medOffice, id);
            return Created("/medOffice", null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _medOfficeService.DeleteMedOffice(id);
            return Created("/medOffice", null);
        }
    }
}