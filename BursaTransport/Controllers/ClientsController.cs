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
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepo;

        public ClientsController(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        [HttpPost("AddClient")]
        [Authorize("AdminClient")]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            if(string.IsNullOrEmpty(client.Name))
            {
                return BadRequest("Name is null");
            }
             await _clientRepo.Create(client);
            return NoContent();
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client =  await _clientRepo.GetById(id);
            return Ok(client);
        }
        [HttpPut("Put")]
        [Authorize("AdminClient")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            await _clientRepo.Update(id, name);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientRepo.Delete(await _clientRepo.GetById(id));
            return Ok();
        }
    }
}
