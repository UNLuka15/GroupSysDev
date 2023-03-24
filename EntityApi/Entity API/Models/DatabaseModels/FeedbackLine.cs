namespace EntityAPI.Models 
{
    public class FeedbackLine
    {
        public int Id { get; set; }
        public string? Field { get; set; }
        public string? Value { get; set; }

        // Don't know if we need this, we may be able to determine this from the feedback type that's passed in.
        public string? DataType { get; set; } 
    }
}
