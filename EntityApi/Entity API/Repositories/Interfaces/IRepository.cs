namespace EntityAPI.Repositories
{
    public interface IRepository<T>
    {
        List<T>? GetAll();

        T? GetById(int id);

        bool RemoveById(int id);

        int? AddNew(T newObject);
    }
}
