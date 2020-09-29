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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SubscriptionResponse> DeleteAsync(int id)
        {
            var existing = await _subscriptionRepository.FindById(id);
            if (existing == null)
                return new SubscriptionResponse("Subscription not found");
            try
            {
                _subscriptionRepository.Remove(existing);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(existing);
            }
            catch(Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while deleting the Subscription: {e.Message}");
            }
        }

        public async Task<SubscriptionResponse> GetById(int id)
        {
            var existing = await _subscriptionRepository.FindById(id);
            if (existing == null)
                return new SubscriptionResponse("Subscription not found");
            return new SubscriptionResponse(existing);
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }

        public async Task<SubscriptionResponse> SaveAsync(Subscription subscription)
        {
            try
            {
                await _subscriptionRepository.AddAsync(subscription);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(subscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while deleting the Subscription: {e.Message}");
            }
        }

        public async Task<SubscriptionResponse> UpdateAsync(int id, Subscription subscription)
        {
            var existing = await _subscriptionRepository.FindById(id);
            if (existing == null)
                return new SubscriptionResponse("Subscription not found");
            existing.Name = subscription.Name;
            try
            {
                _subscriptionRepository.Update(existing);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(existing);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error ocurred while deleting the Subscription: {e.Message}");
            }
        }
    }
}
