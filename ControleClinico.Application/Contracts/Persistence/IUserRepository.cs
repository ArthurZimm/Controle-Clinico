using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<(bool, string,User?)> GetUserByEmail(string email);
        Task<(bool, string, User?)> AuthenticateUser(User login);
        Task<(bool, string)> RegisterUser(User register);
    }
}