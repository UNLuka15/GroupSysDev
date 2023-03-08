﻿using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class ExperienceRepository : IRepository<Experience>
    {
        public bool AddNew(Experience newExperience)
        {
            using (var context = new Context())
            {
                if (context.Experiences != null)
                {
                    context.Exhibits.Attach(newExperience.Exhibit);
                    context.Experiences?.Add(newExperience);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public List<Experience>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Experiences != null)
                    return context.Experiences.Include("Exhibit.Museum")
                                              .Include("Feedback.Lines")
                                              .ToList();

                return null;
            }
        }

        public Experience? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Experiences != null)
                    return context.Experiences.Include("Exhibit.Museum")
                                              .Include("Feedback.Lines")
                                              .SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            using (var context = new Context())
            {
                if (context.Experiences == null)
                    return false;

                var objectToRemove = context.Experiences?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.Experiences?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
