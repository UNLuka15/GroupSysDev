namespace EntityAPI.Models
{
    public class EmailReport
    {
        public int Id { get; set; }
        public Report? Report { get; set; }
        public DateTime? EmailFrequency { get; set; }
        public DateTime? LastSent { get; set; }
        public DateTime? NextDue { get; set; }
    }
}
