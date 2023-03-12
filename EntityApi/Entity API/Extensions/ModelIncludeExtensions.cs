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
    }
}
