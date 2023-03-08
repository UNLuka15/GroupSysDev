using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAPI.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } // encrypted
        public string? PreviousPassword { get; set; } // encrypted
        public DateTime PasswordChanged { get; set; }
        public DateTime? LastLoggedIn { get; set; }
    }
}
