using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class AccountController : WriteBaseController<Account, AccountRequestModel>
    {
        public AccountController(IModelFactory<Account, AccountRequestModel> factory, IRepository<Account> repository) : base(factory, repository)
        {
        }
    }
}
