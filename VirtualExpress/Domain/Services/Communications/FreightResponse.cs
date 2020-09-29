using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class FreightResponse : BaseResponse<Freight>
    {
        public FreightResponse(Freight resource) : base(resource)
        {
        }

        public FreightResponse(string message) : base(message)
        {
        }
    }
}
