using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualExpress.Resource
{
    public class SavePayResource
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime PayDate { get; set; }
    }
}
