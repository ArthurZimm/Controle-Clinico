namespace ControleClinico.Application.Contracts.Services
{
    public interface IAsyncServices<T,T2> where T : class
    {
        Task<(bool result, string message ,IReadOnlyList<T2>)> GetAllAsync();
        Task<(bool result, string message, T2 response)> AddAsync(T entity);
        Task<(bool result, string message, T2 response)> UpdateAsync(T entity);
        Task<(bool result, string message)> DeleteAsync(int id);
    }
}