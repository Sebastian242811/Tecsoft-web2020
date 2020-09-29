using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class PackageResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Observations { get; set; }
        public EPriority Priority { get; set; }
        public EPackageState State { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public Freight Freight { get; set; }
        public Customer Customer { get; set; }
    }
}
