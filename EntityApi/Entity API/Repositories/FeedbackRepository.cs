using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class FeedbackRepository : IReadRepository<Feedback>
    {
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
    }
}
