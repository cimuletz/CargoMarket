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
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepo;

        public VehiclesController(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        [HttpPost("AddVehicle")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> AddVehicle([FromBody] Vehicle vehicle)
        {
            if (string.IsNullOrEmpty(vehicle.NumberPlate))
            {
                return BadRequest("Number plate is null");
            }
            await _vehicleRepo.Create(vehicle);
            return NoContent();
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleRepo.GetById(id);
            return Ok(vehicle);
        }
        [HttpPut("Put")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> Update ([FromQuery]int id, [FromQuery] string numberPlate, [FromQuery] int weight, [FromQuery] int volume)
        {
            await _vehicleRepo.Update(id, numberPlate, weight, volume);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("AdminDriver")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var vehicle = await _vehicleRepo.GetById(id);
            if (vehicle == null)
            {
                return NotFound("Vehicle doesn't exist!");
            }
            await _vehicleRepo.Delete(vehicle);
            return Ok();
        }

    }
}
