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
    public class RootController : Controller
    {
        private readonly IRootService _rootService;

        public RootController(IRootService rootService)
        {
            _rootService = rootService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RootDto>>> Get()
        {
            var roots = await _rootService.GetAll();
            return Json(roots);
        }

        [HttpGet("/id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var root = await _rootService.GetById(id);
            return Json(root);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var root = await _rootService.GetByEmail(email);
            return Json(root);
        }

        [HttpGet("pesel/{pesel}")]
        public async Task<IActionResult> GetByPesel(string pesel)
        {
            var root = await _rootService.GetByPesel(pesel);
            return Json(root);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RootDto root)
        {
            await _rootService.AddRoot(root.Email, root.Password, root.Pesel,
                root.FirstName, root.SecondName, root.PhoneNumber, root.PostCode,
                root.City, root.Street, root.HouseNumber);
            return Created("/roots/5", null);
        }

        [HttpDelete("{rootId}")]
        public async Task<IActionResult> DeleteDoctor(Guid rootId)
        {
            await _rootService.DeleteRoot(rootId);
            return NoContent();
        }

        [HttpPut("{rootId}")]
        public async Task<IActionResult> UpdateDoctor(Guid rootId, [FromBody]RootDto root)
        {
            await _rootService.UpdateRoot(rootId, root.Street, root.PostCode,
                root.PhoneNumber, root.City);

            return NoContent();
        }

    }
}