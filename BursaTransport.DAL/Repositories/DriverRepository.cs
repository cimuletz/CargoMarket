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
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _context;
        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Driver driver)
        {
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
        }

        public async Task<Driver> GetById(int id)
        {
            var driver = await _context.Drivers.Where(x => x.Id == id)
                        .Include(x => x.Vehicle)
                        .Include(x => x.Transports)
                        .FirstOrDefaultAsync();
            return driver;
        }

        public async Task<List<Company>> GetDriverCompanies(int id)
        {
            var companies = await _context.DriverCompanies.Where(x => x.DriverId == id)
                            .Select(x => x.Company)
                            .ToListAsync();
            return companies;
        }

        public async Task Update(int id, string name)
        {
            var driver = await _context.Drivers.Where(x => x.Id == id).FirstOrDefaultAsync();
            driver.Name = name;
            _context.Entry(driver).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
