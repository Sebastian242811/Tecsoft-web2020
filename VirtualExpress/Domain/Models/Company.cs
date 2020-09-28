using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ruc { get; set; }
        public string Number { get; set; }
        public IList<Terminal> Terminals { get; set; } = new List<Terminal>();
        public IList<Driver> Drivers { get; set; } = new List<Driver>();
        public IList<Pay> Pays { get; set; } = new List<Pay>();
        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
