using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
