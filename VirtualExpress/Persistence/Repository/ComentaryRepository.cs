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
    public class ComentaryRepository : BaseRepository, IComentaryRepository
    {
        public ComentaryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Comentary comentary)
        {
            await _context.Comentaries.AddAsync(comentary);
        }

        public async Task<Comentary> FindById(int id)
        {
            return await _context.Comentaries.FindAsync(id); 
        }

        public async Task<IEnumerable<Comentary>> ListAsync()
        {
            return await _context.Comentaries.ToListAsync();
        }

        public void Remove(Comentary Comentary)
        {
            _context.Comentaries.Remove(Comentary);
        }

        public void Update(Comentary Comentary)
        {
            _context.Comentaries.Update(Comentary);
        }
    }
}
