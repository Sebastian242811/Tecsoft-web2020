using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
