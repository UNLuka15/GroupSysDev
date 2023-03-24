using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        public int? AddNew(Account newAccount)
        {
            using (var context = new Context())
            {
                if (context.Accounts != null)
                {
                    context.Logins.Attach(newAccount.Security);
                    context.Museums.Attach(newAccount.Museum);
                    context.EmailReports.Attach(newAccount.EmailReport);
                    context.Accounts?.Add(newAccount);
                    context.SaveChanges();
                    return newAccount.Id;
                }
                else
                    return null;
            }
        }

        public List<Account>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Accounts != null)
                    return context.Accounts.BuildAccount()
                                           .ToList();

                return null;
            }
        }

        public Account? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Accounts != null)
                    return context.Accounts.BuildAccount()
                                           .SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public Account? GetByAccountReference(string accountReference, string museumCode) 
        {
            // TODO: Add defensive programming to this method.
            using (var context = new Context())
            {
                if (context.Accounts != null)
                    return context.Accounts.BuildAccount()
                                           .SingleOrDefault(a => a.Reference == accountReference && a.Museum.Code == museumCode);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            using (var context = new Context())
            {
                if (context.Accounts == null)
                    return false;

                var objectToRemove = context.Accounts?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.Accounts?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
