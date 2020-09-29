using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class ChatResponse : BaseResponse<Chat>
    {
        public ChatResponse(Chat resource) : base(resource)
        {
        }

        public ChatResponse(string message) : base(message)
        {
        }
    }
}
