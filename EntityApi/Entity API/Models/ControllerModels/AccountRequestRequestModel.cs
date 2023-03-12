using System.ComponentModel.DataAnnotations;

namespace EntityAPI.Models
{
    public class AccountRequestRequestModel
    {
        [Required]
        public string AccountReference { get; set; }

        [Required]
        public string MuseumCode { get; set; }

        public bool? Actioned { get; set; }
    }
}
