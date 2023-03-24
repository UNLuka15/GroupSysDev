using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class MuseumRequestModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
        
        [Required]
        public string? Code { get; set; }
    }
}
