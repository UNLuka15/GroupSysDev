namespace EntityAPI.Models
{
    public class Report
    {
        public int Id { get; set; }
        public bool ByExhibit { get; set; }
        public bool ByDate { get; set; }
        public bool ByFeedbackType { get; set; }
        public bool ByKeywords { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ExhibitCodeFilters { get; set; } // Semi-colon delimited string
        public string? FeedbackTypeFilters { get; set; } // Semi-colon delimited string
        public string? Keywords { get; set; } // Semi-colon delimited string
    }
}
