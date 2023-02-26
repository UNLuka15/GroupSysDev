using System.Data.Entity;

namespace EntityAPI.Models
{
    public class Museum
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
    }

    //public class MuseumContext : DbContext
    //{
    //    public DbSet<Museum> Museums { get; set; }
    //}
}
