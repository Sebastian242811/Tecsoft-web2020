using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task AddAsync(Subscription Subscription);
        Task<Subscription> FindById(int id);
        void Update(Subscription Subscription);
        void Remove(Subscription Subscription);
    }
}
