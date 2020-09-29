using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class PayResponse : BaseResponse<Pay>
    {
        public PayResponse(Pay resource) : base(resource)
        {
        }

        public PayResponse(string message) : base(message)
        {
        }
    }
}
