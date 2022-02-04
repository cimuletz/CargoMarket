using BursaTransport.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Interfaces
{
    public interface IClientTransportRepository
    {
        Task<ClientTransport> GetById(int id);
        Task<List<ClientTransport>> GetTransportsByClientId(int id);
        Task<List<ClientTransport>> GetAll();
        Task<List<ClientTransport>> GetBySourceDestDate(string source, string destination, string date);
        Task Create(ClientTransport transport);
        Task Update(int id, decimal price, decimal volume, decimal weight);
        Task Delete(ClientTransport transport);
    }
}
