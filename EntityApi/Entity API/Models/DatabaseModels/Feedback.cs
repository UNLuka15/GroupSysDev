namespace EntityAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public FeedbackType Type {get; set;}
        public List<FeedbackLine>? Lines { get; set; }
    }
}
