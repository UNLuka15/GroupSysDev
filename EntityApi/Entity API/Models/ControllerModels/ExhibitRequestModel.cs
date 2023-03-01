using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Models
{
    [BindProperties]
    public class ExhibitRequestModel
    {
        // TODO: Decide whether this should include the full object, or just an ID
        //public Museum? Museum { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        // TimeOnly isn't supported yet in .NET 6
        public string? OpeningTime { get; set; }
        public string? ClosingTime { get; set; }
    }
}
