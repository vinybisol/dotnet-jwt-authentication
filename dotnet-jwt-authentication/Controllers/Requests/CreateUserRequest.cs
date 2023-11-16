using System.ComponentModel.DataAnnotations;

namespace dotnet_jwt_authentication.Controllers.Requests;

public record CreateUserRequest
{
    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [StringLength(30, MinimumLength = 10)]
    public string Name { get; init; } = string.Empty;

    [StringLength(30, MinimumLength = 10)]
    public string Password { get; init; } = string.Empty;
};
