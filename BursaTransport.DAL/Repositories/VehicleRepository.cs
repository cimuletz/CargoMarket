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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Vehicle vehicle)
        {
            _context.Remove(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle> GetById(int id)
        {
            var vehicles = await _context.Vehicles
                    .Where(x => x.Id == id).FirstOrDefaultAsync();
            return vehicles;
        }

        public async Task Update(int id, string numberPlate, int weight, int volume)
        {
            var vehicle = await _context.Vehicles.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            vehicle.NumberPlate = numberPlate;
            vehicle.MaxWeight = weight;
            vehicle.MaxVolume = volume;
            _context.Vehicles.Attach(vehicle);
        }
    }
}
