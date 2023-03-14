using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class ReportRepository : IRepository<Report>
    {
        public int? AddNew(Report newReport)
        {
            using (var context = new Context())
            {
                if (context.Reports != null)
                {
                    context.Reports?.Add(newReport);
                    context.SaveChanges();
                    return newReport.Id;
                }
                else
                    return null;
            }
        }

        public List<Report>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Reports != null)
                    return context.Reports.ToList();

                return null;
            }
        }

        public Report? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Reports != null)
                    return context.Reports.SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            using (var context = new Context())
            {
                if (context.Reports == null)
                    return false;

                var objectToRemove = context.Reports?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.Reports?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
