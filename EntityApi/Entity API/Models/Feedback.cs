using System.Data.Entity;

namespace EntityAPI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public FeedbackType Type {get; set;}
        public List<FeedbackLine>? Lines { get; set; }
    }

    //public class FeedbackContext : DbContext
    //{
    //    public DbSet<Feedback> FeedbackSet { get; set; }
    //}
}
