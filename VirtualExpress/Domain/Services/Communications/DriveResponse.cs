using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class DriveResponse : BaseResponse<Driver>
    {
        public DriveResponse(Driver resource) : base(resource)
        {
        }

        public DriveResponse(string message) : base(message)
        {
        }
    }
}
