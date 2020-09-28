using System;
using System.Threading.Tasks;
using VirtualExpress.Domain.Persistence.Context;
using VirtualExpress.Domain.Repositories;

namespace VirtualExpress.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
