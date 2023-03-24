using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class EmailReportRepository : IRepository<EmailReport>
    {
        public int? AddNew(EmailReport newEmailReport)
        {
            using (var context = new Context())
            {
                if (context.EmailReports != null)
                {
                    context.Reports.Attach(newEmailReport.Report);
                    context.EmailReports?.Add(newEmailReport);
                    context.SaveChanges();
                    return newEmailReport.Id;
                }
                else
                    return null;
            }
        }

        public List<EmailReport>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.EmailReports != null)
                    return context.EmailReports.BuildEmailReport()
                                               .ToList();

                return null;
            }
        }

        public EmailReport? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.EmailReports != null)
                    return context.EmailReports.BuildEmailReport()
                                               .SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            using (var context = new Context())
            {
                if (context.EmailReports == null)
                    return false;

                var objectToRemove = context.EmailReports?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.EmailReports?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
