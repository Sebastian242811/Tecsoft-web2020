using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface IPayRepository
    {
        Task<IEnumerable<Pay>> ListAsync();
        Task AddAsync(Pay Pay);
        Task<Pay> FindById(int id);
        void Update(Pay Pay);
        void Remove(Pay Pay);
    }
}
