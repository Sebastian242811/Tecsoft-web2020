using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Resource
{
    public class SaveDriverResource
    {
        [Required]
        public string Name { get; set; }
        public string DNI { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
