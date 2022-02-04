using BursaTransport.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver> GetById(int id);
        Task<List<Company>> GetDriverCompanies(int id);
        Task Create(Driver driver);
        Task Update(int id, string name);
        Task Delete(Driver driver);
    }
}
