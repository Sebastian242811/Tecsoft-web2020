using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class FreightResource
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Observations { get; set; }
        public Driver Driver { get; set; }
    }
}
