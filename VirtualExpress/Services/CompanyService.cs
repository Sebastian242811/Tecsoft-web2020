using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Services
{
    public class CompanyService : ICompanyService
    {
        protected readonly ICompanyRepository _companyRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company not found");
            try
            {
                _companyRepository.Remove(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch(Exception e)
            {
                return new CompanyResponse($"An error ocurred while deleting the company: {e.Message}");
            }
        }

        public async Task<CompanyResponse> GetByIdAsync(int id)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company not found");
            return new CompanyResponse(existingCompany);
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch(Exception e)
            {
                return new CompanyResponse($"An error ocurred while saving the company: {e.Message}");
            }
        }

        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.FindById(id);
            if (existingCompany == null)
                return new CompanyResponse("Company not found");
            existingCompany.Name = company.Name;
            try
            {
                _companyRepository.Update(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch(Exception e)
            {
                return new CompanyResponse($"An error ocurred while updating the company: {e.Message}");
            }
        }
    }
}
