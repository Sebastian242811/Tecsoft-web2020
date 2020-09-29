using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class SubscriptionResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public Customer Customer { get; set; }
    }
}
