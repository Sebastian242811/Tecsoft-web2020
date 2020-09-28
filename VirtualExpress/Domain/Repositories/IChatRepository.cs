using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> ListAsync();
        Task AddAsync(Chat Chat);
        Task<Chat> FindById(int id);
        void Remove(Chat Chat);
    }
}
