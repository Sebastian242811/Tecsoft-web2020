using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class PackageResponse : BaseResponse<Package>
    {
        public PackageResponse(Package resource) : base(resource)
        {
        }

        public PackageResponse(string message) : base(message)
        {
        }
    }
}
