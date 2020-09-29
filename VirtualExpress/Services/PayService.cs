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
    public class PayService : IPayService
    {
        private readonly IPayRepository _payRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PayService(IPayRepository payRepository, IUnitOfWork unitOfWork)
        {
            _payRepository = payRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PayResponse> DeleteAsync(int id)
        {
            var existingPay = await _payRepository.FindById(id);
            if (existingPay == null)
                return new PayResponse("Pay not found");
            try
            {
                _payRepository.Remove(existingPay);
                await _unitOfWork.CompleteAsync();

                return new PayResponse(existingPay);
            }
            catch(Exception e)
            {
                return new PayResponse($"An error ocurred while deleting the Pay: {e.Message}");
            }
        }

        public async Task<PayResponse> GetByIdAsync(int id)
        {
            var existingPay = await _payRepository.FindById(id);
            if (existingPay == null)
                return new PayResponse("Pay not found");
            return new PayResponse(existingPay);
        }

        public async Task<IEnumerable<Pay>> ListAsync()
        {
            return await _payRepository.ListAsync();
        }

        public async Task<PayResponse> SaveAsync(Pay pay)
        {
            try
            {
                await _payRepository.AddAsync(pay);
                await _unitOfWork.CompleteAsync();

                return new PayResponse(pay);
            }
            catch (Exception e)
            {
                return new PayResponse($"An error ocurred while saving the Pay: {e.Message}");
            }
        }

        public async Task<PayResponse> UpdateAsync(int id, Pay pay)
        {
            var existingPay = await _payRepository.FindById(id);
            if (existingPay == null)
                return new PayResponse("Pay not found");
            existingPay.Quantity = pay.Quantity;
            try
            {
                _payRepository.Update(existingPay);
                await _unitOfWork.CompleteAsync();

                return new PayResponse(existingPay);
            }
            catch (Exception e)
            {
                return new PayResponse($"An error ocurred while updating the Pay: {e.Message}");
            }
        }
    }
}
