using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class AccountRequestController : WriteBaseController<AccountRequest, AccountRequestRequestModel>
    {
        public AccountRequestController(IModelFactory<AccountRequest, AccountRequestRequestModel> factory, IRepository<AccountRequest> repository) : base(factory, repository)
        {
        }
    }
}
