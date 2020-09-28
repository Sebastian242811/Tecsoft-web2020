using System.ComponentModel.DataAnnotations;

namespace VirtualExpress.Resource
{
    public class SaveCompanyResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(11)]
        public string Ruc { get; set; }
        [Required]
        [MaxLength(9)]
        public string Number { get; set; }
    }
}
