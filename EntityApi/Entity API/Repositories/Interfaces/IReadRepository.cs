namespace EntityAPI.Repositories
{
    public interface IReadRepository<T>
    {
        List<T>? GetAll();

        T? GetById(int id);
    }
}
