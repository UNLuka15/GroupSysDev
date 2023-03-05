using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        public bool AddNew(Feedback newObject)
        {
            throw new NotImplementedException();
        }

        public List<Feedback>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.FeedbackSet != null)
                    return context.FeedbackSet.ToList();

                return null;
            }
        }

        public Feedback? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.FeedbackSet != null)
                    return context.FeedbackSet.SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
