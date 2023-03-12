namespace EntityAPI.Factories
{
    public interface IModelFactory<T, K>
    {
        T Create(K requestModel);
    }
}
