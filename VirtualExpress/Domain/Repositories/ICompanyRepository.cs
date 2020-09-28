using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ListAsync();
        Task AddAsync(Company city);
        Task<Company> FindById(int id);
        void Update(Company city);
        void Remove(Company city);
    }
}
