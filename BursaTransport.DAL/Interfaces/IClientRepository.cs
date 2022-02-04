using BursaTransport.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetById(int id);
        Task Create(Client client);
        Task Update(int id, string name);
        Task Delete(Client client);

    }
}
