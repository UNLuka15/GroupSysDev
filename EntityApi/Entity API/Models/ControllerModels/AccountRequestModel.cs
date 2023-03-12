using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class AccountRequestModel
    {
        [Required]
        public string? Reference { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Phone { get; set; }

        [Required]
        public string? MuseumCode { get; set; }

        public bool? Locked { get; set; }

        public string? LockedUntil { get; set; }

        [Required]
        public string? Role { get; set; }

        public string? Language { get; set; }
    }
}
