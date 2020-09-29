using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResponse> GetByIdAsync(int id)
        {
            var existingCustomer = await _customerRepository.FindById(id);
            if (existingCustomer == null)
                return new CustomerResponse("Customer not found");
            return new CustomerResponse(existingCustomer);
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            var existingCustomer = await _customerRepository.FindById(id);
            if (existingCustomer == null)
                return new CustomerResponse("Customer not found");
            try
            {
                _customerRepository.Remove(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch(Exception e)
            {
                return new CustomerResponse($"An error ocurred while deleting the customer: {e.Message}");
            }
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(customer);
            }
            catch (Exception e)
            {
                return new CustomerResponse($"An error ocurred while saving the customer: {e.Message}");
            }
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _customerRepository.FindById(id);
            if (existingCustomer == null)
                return new CustomerResponse("Customer not found");
            existingCustomer.Name = customer.Name;
            try
            {
                _customerRepository.Remove(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception e)
            {
                return new CustomerResponse($"An error ocurred while updating the customer: {e.Message}");
            }
        }
    }
}
