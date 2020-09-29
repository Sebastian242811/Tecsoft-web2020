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
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        public DriverRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Domain.Models.Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
        }

        public async Task<Domain.Models.Driver> FindById(int id)
        {
            return await _context.Drivers.FindAsync(id);
        }

        public async Task<IEnumerable<Domain.Models.Driver>> ListAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<IEnumerable<Driver>> ListByCompanyId(int companyId)
        {
            return await _context.Drivers
                .Where(p => p.CompanyId == companyId)
                .Include(p => p.Company)
                .ToListAsync();
        }

        public void Remove(Domain.Models.Driver driver)
        {
            _context.Drivers.Remove(driver);
        }

        public void Update(Domain.Models.Driver driver)
        {
            _context.Drivers.Update(driver);
        }

    }
}
