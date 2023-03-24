using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class ExperienceRequestModel
    {
        [Required]
        public string? ExhibitReference { get; set; }

        [Required]
        public string? MuseumCode { get; set; }

        [Required]
        public FeedbackRequestModel? Feedback { get; set; }

        [Required]
        public string? UploadedBy { get; set; }
    }
}
