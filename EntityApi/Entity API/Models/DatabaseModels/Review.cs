namespace EntityAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Provider { get; set; }
        public Museum? Museum { get; set; }
        public DateTime? Date { get; set; }
        public Feedback? Content { get; set; }
    }
}
