using BursaTransport.DAL.Entities;
using BursaTransport.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Repositories
{
    public class ClientTransportRepository : IClientTransportRepository
    {
        private readonly AppDbContext _context;

        public ClientTransportRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(ClientTransport transport)
        {
            await _context.ClientTransports.AddAsync(transport);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ClientTransport transport)
        {
            _context.Remove(transport);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClientTransport>> GetAll()
        {
            //implement date check
            var transports = await _context.ClientTransports
                                 .ToListAsync();
            return transports;
        }

        public async Task<ClientTransport> GetById(int id)
        {
            var transports = await _context.ClientTransports.Where(x => x.Id == id).FirstOrDefaultAsync();
            return transports;
        }

        public async Task<List<ClientTransport>> GetBySourceDestDate(string source, string destination, string date)
        {
            var transports = await _context.ClientTransports.
                            Where(x => x.Source.ToUpper().Equals(source.ToUpper()) 
                            && x.Destination.ToUpper().Equals(destination.ToUpper())
                            && x.Date.ToUpper().Equals(date.ToUpper())).
                            ToListAsync();
            return transports;
        }

        public async Task<List<ClientTransport>> GetTransportsByClientId(int id)
        {
            var transports = await _context.ClientTransports.Where(x => x.ClientId == id).ToListAsync();
            return transports;
        }

        public async Task Update(int id, decimal price, decimal volume, decimal weight)
        {
            var transport = await _context.ClientTransports.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            transport.Price = price;
            transport.Volume = volume;
            transport.Weight = weight;
            _context.Entry(transport).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
