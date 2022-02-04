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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company> GetById(int id)
        {
            var company = await _context.Companies.Where(x => x.Id == id).FirstOrDefaultAsync();
            return company;
        }

        public async Task<List<Driver>> GetCompanyDrivers(int id)
        {
            var drivers = await _context.DriverCompanies.Where(x => x.CompanyId == id).
                              Select(x => x.Driver).
                              ToListAsync();
            return drivers;
        }

        public async Task<decimal> Total(int id)
        {
            var transports = _context.DriverTransports;
            var join = await _context.DriverCompanies.Join(transports, b => b.DriverId, a => a.DriverId, (b, a) => new
                            {
                                b.CompanyId,
                                a.Price
                            })
                            .GroupBy(x => x.CompanyId)
                            .Where(x => x.Key == id)
                            .Select(x => new
                            {
                                Total = x.Sum(x => x.Price)

                            })
                            .FirstOrDefaultAsync();
            return join.Total;
        }

        public async Task Update(int id, string name)
        {
            var company = await _context.Companies.Where(x => x.Id == id).FirstOrDefaultAsync();
            company.Name = name;
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
