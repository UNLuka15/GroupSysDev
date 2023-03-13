using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class ExhibitRepository : IRepository<Exhibit>
    {
        public int? AddNew(Exhibit newExhibit)
        {
            //TODO: Validate object, return false if invalid. Add error handling.

            using (var context = new Context()) 
            {
                if (context.Exhibits != null)
                {
                    context.Museums?.Attach(newExhibit.Museum);
                    context.Exhibits?.Add(newExhibit);
                    context.SaveChanges();
                    return newExhibit.Id;
                }
                else 
                    return null;
            }
        }

        public List<Exhibit>? GetByMuseumCode(string museumCode) 
        {
            using (var context = new Context())
            {
                if (context.Exhibits != null)
                    return context.Exhibits.BuildExhibit().Where(ex => ex.Museum.Code == museumCode).ToList();

                return null;
            }
        }

        public Exhibit? GetByReference(string reference, string museumCode) 
        {
            using (var context = new Context())
            {
                if (context.Exhibits != null)
                    return context.Exhibits.BuildExhibit().SingleOrDefault(ex => ex.Reference == reference &&
                                                            ex.Museum.Code == museumCode);

                return null;
            }
        }

        public List<Exhibit>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Exhibits != null) 
                    return context.Exhibits.BuildExhibit().ToList();

                return null;
            }
        }

        public Exhibit? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Exhibits != null) 
                    return context.Exhibits.BuildExhibit().SingleOrDefault(e => e.Id == id);

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
