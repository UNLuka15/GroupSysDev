using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class AccountRequestRepository : IRepository<AccountRequest>
    {
        public int? AddNew(AccountRequest newAccountRequest)
        {
            using (var context = new Context())
            {
                if (context.AccountRequests != null)
                {
                    context.Museums.Add(newAccountRequest.Museum);
                    context.Accounts.Add(newAccountRequest.Account);
                    context.AccountRequests?.Add(newAccountRequest);
                    context.SaveChanges();
                    return newAccountRequest.Id;
                }
                else
                    return null;
            }
        }

        public List<AccountRequest>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.AccountRequests != null)
                    return context.AccountRequests.BuildAccountRequest()
                                                  .ToList();

                return null;
            }
        }

        public AccountRequest? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.AccountRequests != null)
                    return context.AccountRequests.BuildAccountRequest()
                                                  .SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            using (var context = new Context())
            {
                if (context.AccountRequests == null)
                    return false;

                var objectToRemove = context.AccountRequests?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.AccountRequests?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
