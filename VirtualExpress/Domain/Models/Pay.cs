using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Pay
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public DateTime PayDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
