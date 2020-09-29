using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class SaveTerminalResource
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Direction { get; set; }
    }
}
