using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Comentary
    {
        public int Id { get; set; }
        public string Opinion { get; set; }
        public int Valoration { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int TerminalId { get; set; }
        public Terminal Terminal { get; set; }
    }
}
