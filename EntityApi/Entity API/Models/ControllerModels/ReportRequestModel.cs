using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class ReportRequestModel
    {
        [Required]
        public bool? ByExhibit { get; set; }
        [Required]
        public bool? ByDate { get; set; }
        [Required]
        public bool? ByFeedbackType { get; set; }
        [Required]
        public bool? ByKeywords { get; set; }
        [Required]
        public string? StartDate { get; set; }
        [Required]
        public string? EndDate { get; set; }
        [Required]
        public string? ExhibitCodeFilters { get; set; } // Semi-colon delimited string
        [Required]
        public string? FeedbackTypeFilters { get; set; } // Semi-colon delimited string
        [Required]
        public string? Keywords { get; set; } // Semi-colon delimited string
    }
}
