using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;
using VirtualExpress.Persistence.Repository;

namespace VirtualExpress.Domain.Services
{
    public interface IPayService
    {
        Task<IEnumerable<Pay>> ListAsync();
        Task<PayResponse> GetByIdAsync(int id);
        Task<PayResponse> UpdateAsync(int id, Pay pay);
        Task<PayResponse> DeleteAsync(int id);
        Task<PayResponse> SaveAsync(Pay pay);
    }
}
