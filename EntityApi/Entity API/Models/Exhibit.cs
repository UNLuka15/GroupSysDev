using System.Data.Entity;

namespace EntityAPI.Models
{
    public class Exhibit
    {
        public int Id { get; set; }
        public Museum? Museum { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        // TimeOnly isn't supported yet in .NET 6
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }

    //public class ExhibitContext : DbContext 
    //{
    //    public DbSet<Exhibit> Exhibits { get; set; }
    //}

}
