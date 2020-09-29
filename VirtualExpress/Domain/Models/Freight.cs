using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Freight
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Observations { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public IList<Package> Packages { get; set; } = new List<Package>();

        public Freight()
        {
            this.DepartureDate = DateTime.UtcNow;
        }
    }
}
