namespace ControleClinico.Application.Contracts.Services
{
    public interface IAuthenticationService
    {
        string GenerateToken(string userId, string email);
    }
}