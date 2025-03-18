using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Domain.Entity;
using ControleClinico.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleClinico.Infraestructure.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ClinicalDbContext _clinicalDbContext;

        public UserRepository(ClinicalDbContext clinicalDbContext)
        {
            _clinicalDbContext = clinicalDbContext;
        }

        public async Task<(bool, string, User?)> AuthenticateUser(User login)
        {
            try
            {
                var result = await GetUserByEmail(login.Email);
                if (!result.Item1)
                {
                    return (false, "User not found", default);
                }

                var user = await _clinicalDbContext.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
                if (user == null)
                {
                    return (false, "login or password incorrect", default);
                }
                return (true, string.Empty, user);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, default);
            }
        }

        public async Task<(bool, string, User?)> GetUserByEmail(string email)
        {
            try
            {
                var user = await _clinicalDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user == null)
                {
                    return (false, "User not found", default);
                }
                return (true, string.Empty, user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<(bool, string)> RegisterUser(User register)
        {
            try
            {
                var result = await GetUserByEmail(register.Email);
                if(result.Item1)
                {
                    return (false, "User already exists");
                }
                await _clinicalDbContext.Users.AddAsync(register);
                await _clinicalDbContext.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
