using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task AddAsync(Customer Customer);
        Task<Customer> FindById(int id);
        void Update(Customer Customer);
        void Remove(Customer Customer);
    }
}
