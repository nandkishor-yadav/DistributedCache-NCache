namespace DistributedCache_NCache.Services
{
    public interface IStudent<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
