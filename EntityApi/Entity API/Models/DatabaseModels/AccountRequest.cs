namespace EntityAPI.Models
{
    public class AccountRequest
    {
        public int Id { get; set; }
        public Museum? Museum { get; set; }
        public Account? Account { get; set; }
        public bool Actioned { get; set; }
        public DateTime DateRaised { get; set; }
    }
}
