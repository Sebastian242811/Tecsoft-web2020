using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface ICustumerServiceEmployeeRepository
    {
        Task<IEnumerable<CustomerServiceEmployee>> ListAsync();
        Task AddAsync(CustomerServiceEmployee CustomerServiceEmployee);
        Task<CustomerServiceEmployee> FindById(int id);
        void Update(CustomerServiceEmployee CustomerServiceEmployee);
        void Remove(CustomerServiceEmployee CustomerServiceEmployee);
    }
}
