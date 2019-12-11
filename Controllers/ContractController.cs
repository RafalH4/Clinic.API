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
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        public async Task<IActionResult> AddContract([FromBody]AddContractDto contract)
        {
            await _contractService.AddContract(contract);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDetailsDto>>> GetContracts()
        {
            var contracts = await _contractService.GetAll();
            return Json(contracts);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contract = await _contractService.GetById(id);
            return Json(contract);
        }

        [HttpGet("department/{id}")]
        public async Task<ActionResult<IEnumerable<ContractDetailsDto>>> GetContractsByDepartamentId(Guid id)
        {
            var contracts = await _contractService.GetByDeparamentId(id);
            return Json(contracts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(Guid id)
        {
            await _contractService.DeleteContract(id);
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateContract(Guid id, [FromBody]AddContractDto contract)
        {
            await _contractService.UpdateContract(contract, id);

            return NoContent();
        }
    }
}