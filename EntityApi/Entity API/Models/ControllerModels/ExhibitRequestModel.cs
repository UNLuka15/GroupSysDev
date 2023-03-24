using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class ExhibitRequestModel
    {
        [Required]
        public string? MuseumCode { get; set; }

        [Required]
        public string? Reference { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        // TimeOnly isn't supported yet in .NET 6
        [Required]
        public string? OpeningTime { get; set; }

        [Required]
        public string? ClosingTime { get; set; }
    }
}
