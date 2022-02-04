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
    public class DriverTransportRepository : IDriverTransportRepository
    {

        private readonly AppDbContext _context;

        public DriverTransportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(DriverTransport transport)
        {
            await _context.DriverTransports.AddAsync(transport);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DriverTransport transport)
        {
            _context.Remove(transport);
            await _context.SaveChangesAsync();
        }
        public async Task<List<DriverTransport>> GetAll()
        {
            //implement date check
            var transports = await _context.DriverTransports
                                 .ToListAsync();
            return transports;
        }

        public async Task<DriverTransport> GetById(int id)
        {
            var transports = await _context.DriverTransports.Where(x => x.Id == id).FirstOrDefaultAsync();
            return transports;
        }

        public async Task<List<DriverTransport>> GetBySourceDestDate(string source, string destination, string date)
        {
            var transports = await _context.DriverTransports.
                            Where(x => x.Source.ToUpper().Equals(source.ToUpper())
                            && x.Destination.ToUpper().Equals(destination.ToUpper())
                            && x.Date.ToUpper().Equals(date.ToUpper())).
                            ToListAsync();
            return transports;
        }

        public async Task<List<DriverTransport>> GetTransportsByDriverId(int id)
        {
            var transports = await _context.DriverTransports.Where(x => x.DriverId == id).ToListAsync();
            return transports;
        }

        public async Task Update(int id, decimal price)
        {
            var transport = await _context.DriverTransports.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            transport.Price = price;
            _context.Entry(transport).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
