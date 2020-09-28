using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class CustomerServiceEmployee
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int TerminalId { get; set; }
        public Terminal Terminal { get; set; }
        public IList<Chat> Chats { get; set; } = new List<Chat>();
    }
}
