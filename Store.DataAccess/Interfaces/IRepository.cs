namespace Store.DataAccess.Interfaces;

// CRUD operations
public interface IRepository<T> where T : class
{
    Task<bool> CreateAsync(T item);
    Task<T?> GetAsync(uint id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> UpdateAsync(T item);
    Task<bool> DeleteAsync(uint id);
}