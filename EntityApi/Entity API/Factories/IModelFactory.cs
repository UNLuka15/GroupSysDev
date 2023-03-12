namespace EntityAPI.Factories
{
    /// <summary>
    /// T: Model Type
    /// K: Request Model Type
    /// </summary>
    /// <typeparam name="T">Model Type</typeparam>
    /// <typeparam name="K">Request Model Type</typeparam>
    public interface IModelFactory<T, K>
    {
        T Create(K requestModel);
    }
}
