namespace Feel.Service
{
    public interface IIndexedDbService<T>
    {
        Task<List<T>> GetAllAsync(string storeName);
        Task<T?> GetByIdAsync(string storeName, int id);
        Task PostAsync(string storeName, T item);
        Task UpdateAsync(string storeName, T item);
        Task DeleteAsync(string storeName, object key);
    }
}
