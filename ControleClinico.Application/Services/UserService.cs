using AutoMapper;
using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;
using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IAuthenticationService authenticationService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<(bool, string, UserResponse?)> AuthenticateUser(UserRequest login)
        {
            var result = await _userRepository.AuthenticateUser(_mapper.Map<User>(login));
            if (result.Item1)
            {
                // Gerar o token JWT após a autenticação bem-sucedida
                var token = _authenticationService.GenerateToken(result.Item3!.Id.ToString(), result.Item3.Email);
                return (true, "Usuário autenticado com sucesso", new UserResponse { Email = result.Item3.Email, Name = result.Item3.Name, Token = token});
            }
            return (false, "Usuário ou senha inválidos", null);
        }

        public async Task<(bool, string)> RegisterUser(RegisterRequest register)
        {
            var user = _mapper.Map<User>(register);
            var result = await _userRepository.RegisterUser(user);
            if (result.Item1)
            {
                return (true, "Usuário cadastrado com sucesso");
            }
            return (false, "Erro ao cadastrar usuário");
        }
    }
}
