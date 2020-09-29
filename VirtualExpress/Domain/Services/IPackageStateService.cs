using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Domain.Services
{
    public interface IPackageStateService
    {
        Task<IEnumerable<Package>> ListAsync();
        Task<IEnumerable<Package>> ListByCostumerId(int costumerId);
        Task<PackageResponse> GetInfoToDispatcherByPackageId(int packageId);
        Task<PackageResponse> GetById(int id);
        Task<PackageResponse> SaveAsync(Package package);
        Task<PackageResponse> UpdateAsync(int id, Package package);
        Task<PackageResponse> DeleteAsync(int id);
    }
}
