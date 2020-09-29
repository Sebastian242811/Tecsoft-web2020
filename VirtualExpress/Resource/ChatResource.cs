using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Resource
{
    public class ChatResource
    {
        public int Id { get; set; }
        public string message { get; set; }
        public DateTime PostDate { get; set; }
        public int CustomerId { get; set; }
        public int ServiceEmployeeId { get; set; }
    }
}
