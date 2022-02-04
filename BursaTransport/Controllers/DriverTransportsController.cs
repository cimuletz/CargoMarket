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
    public class DriverTransportsController : ControllerBase
    {
        private readonly IDriverTransportRepository _driverTransportRepo;

        public DriverTransportsController(IDriverTransportRepository driverTransportRepo)
        {
            _driverTransportRepo = driverTransportRepo;
        }

        [HttpPost("AddDriverTransport")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> AddClient([FromBody] DriverTransport driverTransport)
        {
            if (string.IsNullOrEmpty(driverTransport.Source))
            {
                return BadRequest("Source city is null");
            }
            if (string.IsNullOrEmpty(driverTransport.Destination))
            {
                return BadRequest("Destination city is null");
            }
            if (string.IsNullOrEmpty(driverTransport.Date))
            {
                return BadRequest("Date is null");
            }
            await _driverTransportRepo.Create(driverTransport);
            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetTransport(int id)
        {
            var driverTransport = await _driverTransportRepo.GetById(id);
            return Ok(driverTransport);
        }
        [HttpPut("Put")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] decimal price)
        {
            await _driverTransportRepo.Update(id, price);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> Delete(int id)
        {
            var transport = await _driverTransportRepo.GetById(id);
            if(transport == null)
            {
                return BadRequest("Transport doesn't exist!");
            }
            await _driverTransportRepo.Delete(transport);
            return Ok();
        }
        [HttpGet("GetTransportsForDriver")]
        public async Task<IActionResult> GetDriverTransport(int id)
        {
            var transports = await _driverTransportRepo.GetTransportsByDriverId(id);
            return Ok(transports);
        }
        [HttpGet("GetSearch")]
        public async Task<IActionResult> GetSearch([FromQuery] string source, [FromQuery] string destination, [FromQuery] string date)
        {
            var transports = await _driverTransportRepo.GetBySourceDestDate(source, destination, date);
            return Ok(transports);
        }

    }
}
