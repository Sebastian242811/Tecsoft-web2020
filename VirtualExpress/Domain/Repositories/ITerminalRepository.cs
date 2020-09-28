using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface ITerminalRepository
    {
        Task<IEnumerable<Terminal>> ListAsync();
        Task<IEnumerable<Terminal>> ListByCityOriginIdAndCityShipIdAsync(int cityOriginId, int cityShipId);
        Task<IEnumerable<Terminal>> ListByCompanyByIdAsync(int id);
        Task<Terminal> FindByCompanyIdAndCityOriginIdAndCityShipId(int companyId, int cityOriginId, int cityShipId);
        Task<Terminal> FindById(int id);
        Task AddAsync(Terminal terminal);
        void Remove(Terminal terminal);
        //Task AssignTerminal(int companyId, int cityId);
        //Task UnassignTerminal(int companyId, int cityId);
    }
}
