using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class TerminalResponse : BaseResponse<Terminal>
    {
        public TerminalResponse(Terminal resource) : base(resource)
        {
        }

        public TerminalResponse(string message) : base(message)
        {
        }
    }
}
