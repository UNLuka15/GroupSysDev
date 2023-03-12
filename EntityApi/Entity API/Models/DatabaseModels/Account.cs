namespace EntityAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? Reference { get; set; } 
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Login? Security { get; set; }
        public string? Phone { get; set; }
        public Museum? Museum { get; set; }
        public EmailReport? EmailReport { get; set; }
        public AccountRole Role { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedUntil { get; set; }
        public DateTime? Created { get; set; }
        public string? Language { get; set; }
    }
}
