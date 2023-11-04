using dotnet_jwt_authentication.Models;
using dotnet_jwt_authentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt_authentication.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService) => _tokenService = tokenService;

        [HttpPost]
        [Route(nameof(Login))]
        public IActionResult Login([FromBody]User user)
        {
            var token = _tokenService.TokenGenerate(user);
            return Ok(token);
        }

    }
}
