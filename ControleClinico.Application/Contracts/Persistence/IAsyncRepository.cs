namespace ControleClinico.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);
        Task<T?> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}