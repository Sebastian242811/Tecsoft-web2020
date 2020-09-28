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
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Company city)
        {
            await _context.Companies.AddAsync(city);
        }

        public void Remove(Company city)
        {
            _context.Companies.Remove(city);
        }

        public async Task<Company> FindById(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public void Update(Company city)
        {
            _context.Companies.Update(city);
        }
    }
}
