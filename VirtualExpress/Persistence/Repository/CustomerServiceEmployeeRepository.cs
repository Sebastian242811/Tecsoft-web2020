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
    public class CustomerServiceEmployeeRepository : BaseRepository, ICustomerServiceEmployeeRepository
    {
        public CustomerServiceEmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(CustomerServiceEmployee customerServiceEmployee)
        {
            await _context.CustomerServiceEmployees.AddAsync(customerServiceEmployee);
        }

        public async Task<CustomerServiceEmployee> FindById(int id)
        {
            return await _context.CustomerServiceEmployees.FindAsync(id);
        }

        public async Task<IEnumerable<CustomerServiceEmployee>> ListAsync()
        {
            return await _context.CustomerServiceEmployees.ToListAsync();
        }

        public async Task<IEnumerable<CustomerServiceEmployee>> ListByTerminalId(int terminalId)
        {
            return await _context.CustomerServiceEmployees
                .Where(p => p.TerminalId == terminalId)
                .Include(p => p.Terminal)
                .ToListAsync();
        }

        public void Remove(CustomerServiceEmployee customerServiceEmployee)
        {
            _context.CustomerServiceEmployees.Remove(customerServiceEmployee);
        }

        public void Update(CustomerServiceEmployee customerServiceEmployee)
        {
            _context.CustomerServiceEmployees.Update(customerServiceEmployee);
        }
    }
}
