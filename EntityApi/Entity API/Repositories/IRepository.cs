namespace EntityAPI.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(int id);

        bool RemoveById(int id);

        bool AddNew(T newObject);
    }
}
