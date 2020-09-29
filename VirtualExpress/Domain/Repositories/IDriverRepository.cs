using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> ListAsync();
        Task<IEnumerable<Driver>> ListByCompanyId(int companyId);
        Task AddAsync(Driver Driver);
        Task<Driver> FindById(int id);
        void Update(Driver Driver);
        void Remove(Driver Driver);
    }
}
