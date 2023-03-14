using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        public int? AddNew(Account newObject)
        {
            throw new NotImplementedException();
        }

        public List<Account>? GetAll()
        {
            throw new NotImplementedException();
        }

        public Account? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
