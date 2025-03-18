using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace ControleClinico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("/login")]
        public async Task<IActionResult> AuthenticateUser(UserRequest login)
        {
            var result = await _userService.AuthenticateUser(login);
            if (result.Item1)
            {
                return Ok(result.Item3);
            }
            return BadRequest(result.Item2);
        }
        [HttpPost("/register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest register)
        {
            var result = await _userService.RegisterUser(register);
            if (result.Item1)
            {
                return Ok(result.Item2);
            }
            return BadRequest(result.Item2);
        }
    }
}
