using BursaTransport.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetById(int id);
        Task<List<Driver>> GetCompanyDrivers(int id);
        Task Create(Company company);
        Task Update(int id, string name);
        Task Delete(Company company);
        Task<decimal> Total(int id);
    }
}
