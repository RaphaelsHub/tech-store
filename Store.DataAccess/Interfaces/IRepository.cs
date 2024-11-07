namespace Store.DataAccess.Interfaces;

// CRUD operations
public interface IRepository<T> where T : class
{
    Task<bool> CreateAsync(T item);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(uint id);
    Task<bool> UpdateAsync(T item);
    Task<bool> DeleteAsync(uint id);
}