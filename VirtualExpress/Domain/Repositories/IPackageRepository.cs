using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface IPackageRepository
    {
        Task<IEnumerable<Package>> ListAsync();
        Task<IEnumerable<Package>> ListByCostumerId(int costumerId);
        Task AddAsync(Package Package);
        Task<Package> FindById(int id);
        void Update(Package Package);
        void Remove(Package Package);
    }
}
