using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class PayResource
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public DateTime PayDate { get; set; }
        public Company Company { get; set; }
    }
}
