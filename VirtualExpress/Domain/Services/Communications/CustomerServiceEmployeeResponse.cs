using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class CustomerServiceEmployeeResponse : BaseResponse<CustomerServiceEmployee>
    {
        public CustomerServiceEmployeeResponse(CustomerServiceEmployee resource) : base(resource)
        {
        }

        public CustomerServiceEmployeeResponse(string message) : base(message)
        {
        }
    }
}
