using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        public SubscriptionResponse(Subscription resource) : base(resource)
        {
        }

        public SubscriptionResponse(string message) : base(message)
        {
        }
    }
}
