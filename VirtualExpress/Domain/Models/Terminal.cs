using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Terminal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public IList<Dispatcher> Dispatchers { get; set; } = new List<Dispatcher>();
        public IList<CustomerServiceEmployee> ServiceEmployees { get; set; } = new List<CustomerServiceEmployee>();
        public IList<Comentary> Comentaries { get; set; } = new List<Comentary>();
    }
}
