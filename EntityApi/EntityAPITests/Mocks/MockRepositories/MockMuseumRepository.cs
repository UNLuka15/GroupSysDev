using EntityAPI.Models;
using EntityAPI.Repositories;

namespace EntityAPITests
{
    public class MockMuseumRepository : IRepository<Museum>
    {
        public static List<Museum> _museums = new List<Museum>()
        {
            new Museum() { Id = 1, Name = "Test Museum 1", Description = "Test Description 1", Code = "MU01", Exhibits = new List<Exhibit>()},
            new Museum() { Id = 2, Name = "Test Museum 2", Description = "Test Description 2", Code = "MU02", Exhibits = new List<Exhibit>()},
            new Museum() { Id = 3, Name = "Test Museum 3", Description = "Test Description 3", Code = "MU03", Exhibits = new List<Exhibit>()},
            new Museum() { Id = 4, Name = "Test Museum 4", Description = "Test Description 4", Code = "MU04", Exhibits = new List<Exhibit>()},
            new Museum() { Id = 5, Name = "Test Museum 5", Description = "Test Description 5", Code = "MU05", Exhibits = new List<Exhibit>()}
        };

        public int? AddNew(Museum newObject)
        {
            _museums.Add(newObject);
            return newObject.Id;
        }

        public List<Museum>? GetAll()
        {
            return _museums;
        }

        public Museum? GetById(int id)
        {
            return _museums.SingleOrDefault(m => m.Id == id);
        }

        public bool RemoveById(int id)
        {
            var objectToRemove = _museums.SingleOrDefault(m => m.Id == id);

            if (objectToRemove != null)
            {
                _museums.Remove(objectToRemove);
                return true;
            }

            return false;
        }
    }
}
