using EntityAPI.Models;
using EntityAPI.Repositories;

namespace EntityAPI.Factories
{
    public class AccountRequestFactory : IModelFactory<AccountRequest, AccountRequestRequestModel>
    {
        public AccountRequest Create(AccountRequestRequestModel requestModel)
        {
            var accountRequest = new AccountRequest();

            if (requestModel.Actioned.HasValue)
                accountRequest.Actioned = requestModel.Actioned.Value;

            accountRequest.Account = new AccountRepository().GetByAccountReference(requestModel.AccountReference, requestModel.MuseumCode);
            accountRequest.Museum = new MuseumRepository().GetByCode(requestModel.MuseumCode);

            return accountRequest;
        }
    }
}
