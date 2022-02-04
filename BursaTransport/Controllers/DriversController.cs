using BursaTransport.DAL;
using BursaTransport.DAL.Entities;
using BursaTransport.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BursaTransport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverRepository _driverRepo;

        public DriversController(IDriverRepository driverRepo)
        {
            _driverRepo = driverRepo;
        }

        [HttpPost("AddDriver")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> AddClient([FromBody] Driver driver)
        {
            if (string.IsNullOrEmpty(driver.Name))
            {
                return BadRequest("Name is null");
            }
            await _driverRepo.Create(driver);

            return NoContent();
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var driver = await _driverRepo.GetById(id);
            return Ok(driver);
        }
        [HttpPut("Put")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            await _driverRepo.Update(id, name);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var driver = await _driverRepo.GetById(id);
            if (driver == null)
            {
                return BadRequest("Driver doesn't exist");
            }
            await _driverRepo.Delete(driver);
            return Ok();
        }
        [HttpGet("GetCompanies/{id}")]
        public async Task<IActionResult> GetCompanies(int id)
        {
            var companies = await _driverRepo.GetDriverCompanies(id);
            return Ok(companies);
        }
    }
}
