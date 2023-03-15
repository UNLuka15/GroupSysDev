using EntityAPI.Models;
using System.Data.Entity;

namespace EntityAPI
{
    public static class ModelIncludeExtensions
    {
        // Write Extensions to get things auto included.
        public static IQueryable<Exhibit> BuildExhibit(this IQueryable<Exhibit> exhibitContext) 
            => exhibitContext.Include("Museum");

        public static IQueryable<Museum> BuildMuseum(this IQueryable<Museum> museumContext) 
            => museumContext.Include("Exhibits");

        public static IQueryable<Experience> BuildExperience(this IQueryable<Experience> experienceContext) 
            => experienceContext.Include("Exhibit.Museum")
                                .Include("Feedback.Lines");

        public static IQueryable<Review> BuildReview(this IQueryable<Review> reviewContext)
            => reviewContext.Include("Content.Lines");

        public static IQueryable<Account> BuildAccount(this IQueryable<Account> accountContext)
            => accountContext.Include("Security")
                             .Include("Museum")
                             .Include("EmailReport.Report");

        public static IQueryable<AccountRequest> BuildAccountRequest(this IQueryable<AccountRequest> accountRequestContext)
            => accountRequestContext.Include("Account")
                                    .Include("Museum");

        public static IQueryable<EmailReport> BuildEmailReport(this IQueryable<EmailReport> emailReportContext)
            => emailReportContext.Include("Report");

        public static IQueryable<Feedback> BuildFeedback(this IQueryable<Feedback> feedbackContext)
            => feedbackContext.Include("Lines");
    }
}
