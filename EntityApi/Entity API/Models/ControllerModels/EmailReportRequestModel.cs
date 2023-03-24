using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class EmailReportRequestModel
    {
        [Required]
        public string? ReportId { get; set; }

        [Required]
        public string? EmailFrequency { get; set; }

        [Required]
        public string? LastSent { get; set; }
        
        [Required]
        public string? NextDue { get; set; }

    }
}
