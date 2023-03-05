namespace EntityAPI.Models
{
    public class Exhibit
    {
        public int Id { get; set; }
        public Museum? Museum { get; set; }
        public string? Reference { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        // TimeOnly isn't supported yet in .NET 6
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }
    }
}
