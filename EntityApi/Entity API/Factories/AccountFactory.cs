using EntityAPI.Models;
using EntityAPI.Repositories;

namespace EntityAPI.Factories
{
    public class AccountFactory : IModelFactory<Account, AccountRequestModel>
    {
        public Account Create(AccountRequestModel requestModel)
        {
            // TODO: Add a check to confirm that Account Reference isn't duplicated for that museum.
            var account = new Account();
            
            account.Reference = requestModel.Reference;
            account.Email = requestModel.Email;
            account.FirstName = requestModel.FirstName;
            account.LastName = requestModel.LastName;
            account.Security = GetLogin(requestModel.Email, requestModel.Password);
            account.Phone = requestModel.Phone;
            account.Museum = new MuseumRepository().GetById(Int32.Parse(requestModel.MuseumCode));
            account.EmailReport = new EmailReportRepository().GetById(Int32.Parse(requestModel.EmailReportId));
            account.Role = requestModel.Role.ToEnum<AccountRole>();
            account.IsLocked = requestModel.Locked.Value;
            account.LockedUntil = DateTime.Parse(requestModel.LockedUntil);
            account.Created = DateTime.Now;
            account.Language = requestModel.Language;

            return account;
        }

        public Login GetLogin(string email, string password) 
        {
            var login = new Login();

            login.Email = email;
            login.PreviousPassword = login.Password ?? string.Empty;
            login.Password = password;
            login.PasswordChanged = DateTime.Now;
            login.LastLoggedIn = DateTime.Now;

            return login;
        }
    }
}
