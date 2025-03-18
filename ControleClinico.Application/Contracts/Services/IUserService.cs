using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;

namespace ControleClinico.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<(bool, string, UserResponse?)> AuthenticateUser(UserRequest login);
        Task<(bool, string)> RegisterUser(RegisterRequest register);
    }
}