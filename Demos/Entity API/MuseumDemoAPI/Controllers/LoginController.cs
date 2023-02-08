using Microsoft.AspNetCore.Mvc;
using MuseumDemoAPI.Models;

namespace MuseumDemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet("All")]
        public List<Account> GetAccountList()
        {
            List<Account> accounts = new List<Account>();

            using (var db = new AccountContext())
            {
                accounts = db.Accounts.ToList();
            }

            return accounts;
        }
    }
}
