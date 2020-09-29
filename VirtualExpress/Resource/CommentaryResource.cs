using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class CommentaryResource
    {
        public int Id { get; set; }
        public string Opinion { get; set; }
        public int Valoration { get; set; }
        public Customer Customer { get; set; }
        public Terminal Terminal { get; set; }
    }
}
