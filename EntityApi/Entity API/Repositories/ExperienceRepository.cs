using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class ExperienceRepository : IRepository<Experience>
    {
        public bool AddNew(Experience newObject)
        {
            throw new NotImplementedException();
        }

        public List<Experience>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Experiences != null)
                    return context.Experiences.ToList();

                return null;
            }
        }

        public Experience? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Experiences != null)
                    return context.Experiences.SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
