namespace ControleClinico.Application.Contracts.Persistence
{
    public interface IAsynRepository<T> where T : class
    {
        Task<(bool result, string message, T)> GetByIdAsync(int id);
        Task<(bool result, string message, IReadOnlyList<T>)> ListAllAsync();
        Task<(bool result, string message, T)> AddAsync(T entity);
        Task<(bool result, string message)> UpdateAsync(T entity);
        Task<(bool result, string message)> DeleteAsync(T entity);
    }
}