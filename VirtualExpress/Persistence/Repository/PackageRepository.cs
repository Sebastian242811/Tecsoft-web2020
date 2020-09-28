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
    public class PackageRepository : BaseRepository, IPackageRepository
    {
        public PackageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Package package)
        {
            await _context.Packages.AddAsync(package);
        }

        public async Task<Package> FindById(int id)
        {
            return await _context.Packages.FindAsync(id);
        }

        public async Task<IEnumerable<Package>> ListAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public void Remove(Package package)
        {
            _context.Packages.Remove(package);
        }

        public void Update(Package package)
        {
            _context.Packages.Update(package);
        }
    }
}
