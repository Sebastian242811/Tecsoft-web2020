using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<CustomerResponse> GetByIdAsync(int id);
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        Task<CustomerResponse> DeleteAsync(int id);
    }
}
