using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class FeedbackLineRequestModel
    {
        [Required]
        public string? Field { get; set; }

        [Required]
        public string? Value { get; set; }


        // Don't know if we need this, we may be able to determine this from the feedback type that's passed in.
        [Required]
        public string? DataType { get; set; }
    }
}
