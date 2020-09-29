using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class DispatcherResponse : BaseResponse<Dispatcher>
    {
        public DispatcherResponse(Dispatcher resource) : base(resource)
        {
        }

        public DispatcherResponse(string message) : base(message)
        {
        }
    }
}
