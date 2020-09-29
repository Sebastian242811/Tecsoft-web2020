using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Direction { get; set; }
        public string EMail { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public IList<Package> Packages { get; set; } = new List<Package>();
        public IList<Chat> Chats { get; set; } = new List<Chat>();
        public IList<Comentary> Comentaries { get; set; } = new List<Comentary>();
        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
