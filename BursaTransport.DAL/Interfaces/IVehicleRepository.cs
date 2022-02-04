using BursaTransport.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetById(int id);
        Task Create(Vehicle vehicle);
        Task Update(int id, string numberPlate, int weight, int volume);
        Task Delete(Vehicle vehicle);
    }
}
