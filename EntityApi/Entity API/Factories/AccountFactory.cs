using EntityAPI.Models;

namespace EntityAPI.Factories
{
    public class AccountFactory : IModelFactory<Account, AccountRequestModel>
    {
        public Account Create(AccountRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
