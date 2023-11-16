using dotnet_jwt_authentication.Controllers.Requests;
using dotnet_jwt_authentication.Data;
using dotnet_jwt_authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_jwt_authentication.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController(UserContext userContext) : ControllerBase
    {
        private readonly UserContext _userContext = userContext;

        [HttpPost]
        [Route(nameof(CreateAsync))]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest userRequest)
        {
            User user = new()
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = userRequest.Password
            };

            await _userContext.Users.AddAsync(user);

            await _userContext.SaveChangesAsync();

            return Ok("User created");
        }
    }
}
