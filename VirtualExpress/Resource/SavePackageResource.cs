using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Resource
{
    public class SavePackageResource
    {
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Observations { get; set; }

        [Required]
        [MaxLength(5)]
        public string Priority { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }
    }
}
