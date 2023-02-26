using System.Data.Entity;

namespace EntityAPI.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public Exhibit? Exhibit { get; set; }
        public DateTime? DateEntered { get; set; }
        public Feedback? Feedback { get; set; }
        public string? UploadedBy { get; set; }
    }

    //public class ExperienceContext : DbContext
    //{
    //    public DbSet<Experience> Experiences { get; set; }
    //}
}
