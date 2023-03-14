using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class AccountController : WriteBaseController<Account, AccountRequestModel>
    {
        // Account/Login
        public override IModelFactory<Account, AccountRequestModel> _factory => new AccountFactory();
        public override IRepository<Account> _repository => new AccountRepository();
    }
}
