using BursaTransport.DAL.Entities;
using BursaTransport.DAL.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context; 
        }
        public async Task Create(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetById(int id)
        {
            var client = await _context.Clients.Where(x => x.Id == id).
                Include(x => x.Transports).FirstOrDefaultAsync();
            return client;
        }

        public async Task Update(int id, string name)
        {
            var client = await _context.Clients.AsNoTracking().
                FirstOrDefaultAsync(x => x.Id == id);

            client.Name = name;
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
