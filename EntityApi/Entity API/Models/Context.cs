using System.Data.Entity;

namespace EntityAPI.Models
{
    public class Context : DbContext
    {
        public Context() : base("MuseumDev") { }

        public DbSet<Exhibit>? Exhibits { get; set; }
        public DbSet<Experience>? Experiences { get; set; }
        public DbSet<Feedback>? FeedbackSet { get; set; }
        public DbSet<FeedbackLine>? FeedbackLines { get; set; }
        public DbSet<Museum>? Museums { get; set; }
    }
}
