using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Resource
{
    public class DriverResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DNI { get; set; }
        public string Telephone { get; set; }
        public int CompanyId { get; set; }
    }
}
