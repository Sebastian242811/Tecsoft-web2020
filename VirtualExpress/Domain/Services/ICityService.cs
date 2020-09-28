using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Domain.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        Task<CityResponse> GetByIdAsync(int id);
        Task<CityResponse> SaveAsynnc(City city);
        Task<CityResponse> UpdateAsync(int id, City city);
        Task<CityResponse> DeleteAsync(int id);
    }
}
