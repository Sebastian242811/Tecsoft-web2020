using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Domain.Services
{
    public interface ICustomerServiceEmployeeService
    {
        Task<IEnumerable<CustomerServiceEmployee>> ListAsync();
        Task<CustomerServiceEmployeeResponse> GetByIdAsync(int id);
        Task<IEnumerable<CustomerServiceEmployee>> GetByTerminalIdAsync(int terminalId);
        Task<CustomerServiceEmployeeResponse> SaveAsync(CustomerServiceEmployee customerServiceEmployee);
        Task<CustomerServiceEmployeeResponse> UpdateAsync(int id, CustomerServiceEmployee customerServiceEmployee);
        Task<CustomerServiceEmployeeResponse> DeleteAsync(int id);
    }
}
