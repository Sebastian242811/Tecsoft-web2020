using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> ListAsync();
        Task<CompanyResponse> GetByIdAsync(int id);
        Task<CompanyResponse> SaveAsync(Company company);
        Task<CompanyResponse> UpdateAsync(int id, Company company);
        Task<CompanyResponse> DeleteAsync(int id);
    }
}
