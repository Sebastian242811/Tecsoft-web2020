using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class TerminalResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public City City { get; set; }
        public Company Company { get; set; }
    }
}
