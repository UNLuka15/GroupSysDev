using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class FeedbackRequestModel
    {
        [Required]
        public string? FeedbackType { get; set; }

        [Required]
        public List<FeedbackLineRequestModel>? Lines { get; set; }
    }
}
