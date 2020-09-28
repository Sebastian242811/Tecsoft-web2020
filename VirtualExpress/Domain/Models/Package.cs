using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Observations { get; set; }
        public EPriority Priority { get; set; }
        public EPackageState State { get; set; }
        public int DispatcherId { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public int FreightId { get; set; }
        public Freight Freight { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
