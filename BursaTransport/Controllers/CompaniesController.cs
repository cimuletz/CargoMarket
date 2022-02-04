using BursaTransport.DAL;
using BursaTransport.DAL.Entities;
using BursaTransport.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BursaTransport.Controllers
{
    public class SerializerClass
    {
        public decimal totalPrice { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;
        public CompaniesController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpPost("AddCompany")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> AddClient([FromBody] Company company)
        {
            if (string.IsNullOrEmpty(company.Name))
            {
                return BadRequest("Name is null");
            }
            await _companyRepo.Create(company);

            return NoContent();
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _companyRepo.GetById(id);
            return Ok(company);
        }
        [HttpGet("GetTotal/{id}")]
        public async Task<IActionResult> GetTotal(int id)
        {
            var company =  await _companyRepo.GetById(id); //this check should probably be done in the repo?
            if(company == null)
            {
                return BadRequest("Company doesn't exist");
            }
            var total = await _companyRepo.Total(id);
            var json = new SerializerClass
            {
                totalPrice = total
            };
            string output = JsonConvert.SerializeObject(json);
            return Ok(output);

        }
        [HttpPut("Put")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            await _companyRepo.Update(id, name);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var company = await _companyRepo.GetById(id);
            if (company == null)
            {
                return NotFound("Company doesn't exist!");
            }
            await _companyRepo.Delete(company);
            return Ok();
        }
        [HttpGet("GetDrivers/{id}")]
        public async Task<IActionResult> GetDrivers(int id)
        {
            var drivers = await _companyRepo.GetCompanyDrivers(id);
            return Ok(drivers);
        }
    }
}
