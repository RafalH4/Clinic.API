using System;
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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
        {
            var departaments= await _departmentService.GetAll();
            return Json(departaments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(Guid id)
            => await _departmentService.GetById(id);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddDepartmentDto department)
        {
            await _departmentService.AddDepartment(department);
            return Created("/department", null);
        }

        [HttpPut]
        public async Task<IActionResult> EditDepartment([FromBody] AddDepartmentDto department)
        { 
            await _departmentService.UpdateDepartment(department);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            await _departmentService.DeleteDepartment(id);
            return NoContent();
        }
    }
}