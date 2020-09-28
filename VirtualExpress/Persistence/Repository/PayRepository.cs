using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Persistence.Context;
using VirtualExpress.Domain.Repositories;

namespace VirtualExpress.Persistence.Repository
{
    public class PayRepository : BaseRepository, IPayRepository
    {
        public PayRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Pay pay)
        {
            await _context.Pays.AddAsync(pay);
        }

        public async Task<Pay> FindById(int id)
        {
            return await _context.Pays.FindAsync(id);
        }

        public async Task<IEnumerable<Pay>> ListAsync()
        {
            return await _context.Pays.ToListAsync();
        }

        public void Remove(Pay pay)
        {
            _context.Pays.Remove(pay);
        }

        public void Update(Pay pay)
        {
            _context.Pays.Update(pay);
        }
    }
}
