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
    public class FreightRepository : BaseRepository, IFreightRepository
    {
        public FreightRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Freight freight)
        {
            await _context.Freights.AddAsync(freight);
        }

        public async Task<Freight> FindById(int id)
        {
            return await _context.Freights.FindAsync(id);
        }

        public async Task<IEnumerable<Freight>> ListAsync()
        {
            return await _context.Freights.ToListAsync();
        }

        public async Task<IEnumerable<Freight>> ListByMothAndYearDate(int month, int year)
        {
            return await _context.Freights
                .Where(p => p.DepartureDate.Year == year)
                .Where(p => p.DepartureDate.Month == month)
                .Include(p => p.Driver)
                .ToListAsync();
        }

        public void Remove(Freight freight)
        {
            _context.Freights.Remove(freight);
        }

        public void Update(Freight freight)
        {
            _context.Freights.Update(freight);
        }
    }
}
