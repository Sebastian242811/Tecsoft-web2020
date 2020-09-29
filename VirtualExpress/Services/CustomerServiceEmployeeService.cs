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
    public class CustomerServiceEmployeeService : ICustomerServiceEmployeeService
    {
        private readonly ICustomerServiceEmployeeRepository _customerServiceEmployeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerServiceEmployeeService(ICustomerServiceEmployeeRepository customerServiceEmployeeRepository, IUnitOfWork unitOfWork)
        {
            _customerServiceEmployeeRepository = customerServiceEmployeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerServiceEmployeeResponse> DeleteAsync(int id)
        {
            var existingCustomerEmployee = await _customerServiceEmployeeRepository.FindById(id);
            if (existingCustomerEmployee == null)
                return new CustomerServiceEmployeeResponse("Customer Employee not found");
            try
            {
                _customerServiceEmployeeRepository.Remove(existingCustomerEmployee);
                await _unitOfWork.CompleteAsync();

                return new CustomerServiceEmployeeResponse(existingCustomerEmployee);
            }
            catch(Exception e)
            {
                return new CustomerServiceEmployeeResponse($"An error ocurred while deleting the Employee: {e.Message}");
            }
        }

        public async Task<CustomerServiceEmployeeResponse> GetByIdAsync(int id)
        {
            var existingCustomerEmployee = await _customerServiceEmployeeRepository.FindById(id);
            if (existingCustomerEmployee == null)
                return new CustomerServiceEmployeeResponse("Customer Employee not found");
            return new CustomerServiceEmployeeResponse(existingCustomerEmployee);
        }

        public async Task<IEnumerable<CustomerServiceEmployee>> GetByTerminalIdAsync(int terminalId)
        {
            return await _customerServiceEmployeeRepository.ListByTerminalId(terminalId);
        }

        public async Task<IEnumerable<CustomerServiceEmployee>> ListAsync()
        {
            return await _customerServiceEmployeeRepository.ListAsync();
        }

        public async Task<CustomerServiceEmployeeResponse> SaveAsync(CustomerServiceEmployee customerServiceEmployee)
        {
            try
            {
                await _customerServiceEmployeeRepository.AddAsync(customerServiceEmployee);
                await _unitOfWork.CompleteAsync();

                return new CustomerServiceEmployeeResponse(customerServiceEmployee);
            }
            catch (Exception e)
            {
                return new CustomerServiceEmployeeResponse($"An error ocurred while saving the Employee: {e.Message}");
            }
        }

        public async Task<CustomerServiceEmployeeResponse> UpdateAsync(int id, CustomerServiceEmployee customerServiceEmployee)
        {
            var existingEmployee = await _customerServiceEmployeeRepository.FindById(id);
            if (existingEmployee == null)
                return new CustomerServiceEmployeeResponse("Employee not found");
            existingEmployee.Name = customerServiceEmployee.Name;
            try
            {
                _customerServiceEmployeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new CustomerServiceEmployeeResponse(existingEmployee);
            }
            catch (Exception e)
            {
                return new CustomerServiceEmployeeResponse($"An error ocurred while updating the Employee: {e.Message}");
            }
        }
    }
}
