using System.ComponentModel.DataAnnotations;

namespace VirtualExpress.Resource
{
    public class SaveCityResource
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
