using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface IComentaryRepository
    {
        Task<IEnumerable<Comentary>> ListAsync();
        Task AddAsync(Comentary Comentary);
        Task<Comentary> FindById(int id);
        void Update(Comentary Comentary);
        void Remove(Comentary Comentary);
    }
}
