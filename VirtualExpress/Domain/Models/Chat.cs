using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string message { get; set; }
        public DateTime PostDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceEmployeeId { get; set; }
        public CustomerServiceEmployee ServiceEmployee { get; set; }
    }
}
