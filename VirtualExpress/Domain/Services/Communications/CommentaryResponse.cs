using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Services.Communications
{
    public class CommentaryResponse : BaseResponse<Comentary>
    {
        public CommentaryResponse(Comentary resource) : base(resource)
        {
        }

        public CommentaryResponse(string message) : base(message)
        {
        }
    }
}
