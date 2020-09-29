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
    public class ChatRepository : BaseRepository, IChatRepository
    {
        public ChatRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
        }

        public async Task<Chat> FindById(int id)
        {
            return await _context.Chats.FindAsync(id);
        }

        public async Task<IEnumerable<Chat>> ListAsync()
        {
            return await _context.Chats.ToListAsync();
        }

        public async Task<IEnumerable<Chat>> ListByUserIdAndEmployeeId(int userId, int employeeId)
        {
            return await _context.Chats
                .Where(p => p.CustomerId == userId)
                .Where(p => p.ServiceEmployeeId == employeeId)
                .Include(p => p.Customer)
                .Include(p => p.ServiceEmployee)
                .ToListAsync();
        }

        public void Remove(Chat chat)
        {
            _context.Chats.Remove(chat);
        }
    }
}
