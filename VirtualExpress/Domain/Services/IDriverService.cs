using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Domain.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> ListAsync();
        Task<IEnumerable<Driver>> ListByCompanyId(int companyId);
        Task<DriveResponse> GetById(int id);
        Task<DriveResponse> SaveAsync(Driver driver);
        Task<DriveResponse> UpdateAsync(int id, Driver driver);
        Task<DriveResponse> DeleteAsync(int id);
    }
}
