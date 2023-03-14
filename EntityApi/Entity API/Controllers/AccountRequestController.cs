using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class AccountRequestController : WriteBaseController<AccountRequest, AccountRequestRequestModel>
    {
        public override IModelFactory<AccountRequest, AccountRequestRequestModel> _factory => new AccountRequestFactory();
        public override IRepository<AccountRequest> _repository => new AccountRequestRepository();
    }
}
