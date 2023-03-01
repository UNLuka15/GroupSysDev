using EntityAPI.Models;
using System.Linq;

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

        public List<Exhibit> GetAll()
        {
            using (var context = new Context())
            {
                return context.Exhibits != null ? context.Exhibits.ToList() : new List<Exhibit>();
            }
        }

        public Exhibit GetById(int id)
        {
            using (var context = new Context())
            {
                return context.Exhibits?.SingleOrDefault(e => e.Id == id) ?? new Exhibit();
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
