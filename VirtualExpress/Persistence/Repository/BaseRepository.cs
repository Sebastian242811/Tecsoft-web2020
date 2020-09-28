using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Persistence.Context;

namespace VirtualExpress.Persistence.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
