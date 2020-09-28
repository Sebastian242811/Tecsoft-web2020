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
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(City city)
        {
            await _context.Cities.AddAsync(city);
        }

        public void Remove(City city)
        {
            _context.Cities.Remove(city);
        }

        public async Task<City> FindById(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public void Update(City city)
        {
            _context.Cities.Update(city);
        }
    }
}
