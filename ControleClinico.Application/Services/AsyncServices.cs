using ControleClinico.Application.Contracts.Services;

namespace ControleClinico.Application.Services
{
    public class AsyncServices<T, T2> : IAsyncServices<T, T2> where T : class
    {
        public Task<(bool result, string message, T2 response)> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, string message)> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, string message, IReadOnlyList<T2>)> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(bool result, string message, T2 response)> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}