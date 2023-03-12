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
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<AccountRequest>? AccountRequests { get; set; }
        public DbSet<Login>? Logins { get; set; }
        public DbSet<Report>? Reports { get; set; }
        public DbSet<EmailReport>? EmailReports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exhibit>()
                        .HasOptional(e => e.Museum)
                        .WithMany(m => m.Exhibits)
                        .WillCascadeOnDelete();
        }
    }
}
