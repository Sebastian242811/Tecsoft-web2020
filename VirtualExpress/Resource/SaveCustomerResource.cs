using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Resource
{
    public class SaveCustomerResource
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Direction { get; set; }
        public string EMail { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
    }
}
