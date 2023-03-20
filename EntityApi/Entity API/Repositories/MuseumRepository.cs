﻿using EntityAPI.Models;

namespace EntityAPI.Repositories
{
    public class MuseumRepository : IRepository<Museum>
    {
        public int? AddNew(Museum newMuseum)
        {
            using (var context = new Context())
            {
                if (context.Museums != null)
                {
                    context.Museums?.Add(newMuseum);
                    context.SaveChanges();
                    return newMuseum.Id;
                }
                else
                    return null;
            }
        }

        public List<Museum>? GetAll()
        {
            using (var context = new Context())
            {
                if (context.Museums != null)
                    return context.Museums.BuildMuseum().ToList();

                return null;
            }
        }

        public Museum? GetById(int id)
        {
            using (var context = new Context())
            {
                if (context.Museums != null)
                    return context.Museums.SingleOrDefault(e => e.Id == id);

                return null;
            }
        }

        public Museum? GetByCode(string code)
        {
            using (var context = new Context())
            {
                if (context.Museums != null)
                    return context.Museums.SingleOrDefault(e => e.Code == code);

                return null;
            }
        }

        public Museum? GetByName(string name) 
        {
            using(var context = new Context())
            {
                if (context.Museums != null)
                    return context.Museums.SingleOrDefault(e => e.Name == name);

                return null;
            }
        }

        public bool RemoveById(int id)
        {
            using (var context = new Context())
            {
                if (context.Museums == null)
                    return false;

                var objectToRemove = context.Museums?.SingleOrDefault(e => e.Id == id);

                if (objectToRemove != default)
                {
                    context.Museums?.Remove(objectToRemove);
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
