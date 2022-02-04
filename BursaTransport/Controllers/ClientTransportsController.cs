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
    public class ClientTransportsController : ControllerBase
    {
        private readonly IClientTransportRepository _clientTransportRepo;

        public ClientTransportsController(IClientTransportRepository clientTransportRepo)
        {
            _clientTransportRepo = clientTransportRepo;
        }

        [HttpPost("AddClientTransport")]
        [Authorize("AdminClient")]
        public async Task<IActionResult> AddClient([FromBody] ClientTransport clientTransport)
        {
            if (string.IsNullOrEmpty(clientTransport.Source))
            {
                return BadRequest("Source city is null");
            }
            if (string.IsNullOrEmpty(clientTransport.Destination))
            {
                return BadRequest("Destination city is null");
            }
            if (string.IsNullOrEmpty(clientTransport.Date))
            {
                return BadRequest("Date is null");
            }
            await _clientTransportRepo.Create(clientTransport);
            return NoContent();
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var clientTransport = await _clientTransportRepo.GetById(id);
            return Ok(clientTransport);
        }
        [HttpGet("GetTransportsForClient/{id}")]
        public async Task<IActionResult> GetClientTransports(int id)
        {
            var transports = await _clientTransportRepo.GetTransportsByClientId(id);
            return Ok(transports);
        }
        [HttpPut("Put")]
        [Authorize("AdminClient")]
        public async Task<IActionResult> Update ([FromQuery] int id, [FromQuery] decimal price, [FromQuery] decimal volume, [FromQuery] decimal weight)
        {
            await _clientTransportRepo.Update(id, price, volume, weight);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("AdminClient")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            var transport = await _clientTransportRepo.GetById(id);
            if (transport == null)
            {
                return BadRequest("Transport doesn't exist!");
            }
            await _clientTransportRepo.Delete(await _clientTransportRepo.GetById(id));
            return Ok();
        }
        [HttpGet("GetSearch")]
        public async Task<IActionResult> GetSearch([FromQuery] string source, [FromQuery] string destination, [FromQuery] string date)
        {
            var transports = await _clientTransportRepo.GetBySourceDestDate(source, destination, date);
            return Ok(transports);
        }
    }
}
