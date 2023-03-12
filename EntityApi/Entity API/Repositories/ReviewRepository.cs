﻿using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        public bool AddNew(Review newReview)
        {
            using (var context = new Context())
            {
                if (context.Reviews != null)
                {
                    context.Reviews?.Add(newReview);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public List<Review>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Reviews != null)
                    return context.Reviews.BuildReview()
                                          .ToList();

                return null;
            }
        }

        public Review? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Reviews != null)
                    return context.Reviews.BuildReview()
                                          .SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            using (var context = new Context())
            {
                if (context.Reviews == null)
                    return false;

                var objectToRemove = context.Reviews?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.Reviews?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
