using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class ExhibitRepository : IRepository<Exhibit>
    {
        public bool AddNew(Exhibit newExhibit)
        {
            //TODO: Validate object, return false if invalid. Add error handling.

            using (var context = new Context()) 
            {
                if (context.Exhibits != null)
                {
                    context.Exhibits?.Add(newExhibit);
                    context.SaveChanges();
                    return true;
                }
                else 
                    return false;
            }
        }

        public List<Exhibit>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Exhibits != null) 
                    return context.Exhibits.ToList();

                return null;
            }
        }

        public Exhibit? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Exhibits != null) 
                    return context.Exhibits.SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            // TODO: Add error handling to return false if not deleted.

            using (var context = new Context()) 
            {
                if (context.Exhibits == null)
                    return false;

                var objectToRemove = context.Exhibits?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.Exhibits?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
