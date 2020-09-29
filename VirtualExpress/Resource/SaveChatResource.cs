using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Resource
{
    public class SaveChatResource
    {
        [Required]
        public string message { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime PostDate { get; set; }
        [Required]
        public int ServiceEmployeeId { get; set; }
    }
}
