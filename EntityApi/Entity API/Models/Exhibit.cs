using System.Data.Entity;

namespace EntityAPI.Models
{
    public class Exhibit
    {
        public int Id { get; set; }
        public Museum? Museum { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
    }

    //public class ExhibitContext : DbContext 
    //{
    //    public DbSet<Exhibit> Exhibits { get; set; }
    //}

}
