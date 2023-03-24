using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class ReviewRequestModel
    {
        [Required]
        public string? Provider { get; set; }

        [Required]
        public string? Date { get; set; }

        [Required]
        public string? MuseumName { get; set; }

        [Required]
        public FeedbackRequestModel? Content { get; set; }
    }
}
