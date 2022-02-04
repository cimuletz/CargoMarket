using BursaTransport.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Interfaces
{
    public interface IDriverTransportRepository
    {
        Task<DriverTransport> GetById(int id);
        Task<List<DriverTransport>> GetTransportsByDriverId(int id);
        Task<List<DriverTransport>> GetAll();
        Task<List<DriverTransport>> GetBySourceDestDate(string source, string destination, string date);
        Task Create(DriverTransport transport);
        Task Update(int id, decimal price);
        Task Delete(DriverTransport transport);
    }
}
