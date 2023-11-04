using System.ComponentModel.DataAnnotations;

namespace dotnet_jwt_authentication.Models;

public record User
{
    public Guid Id { get; init; }

    [EmailAddress]
    public string Email { get; init; } = string.Empty;

    [StringLength(30, MinimumLength = 10)]
    public string Password { get; init; } = string.Empty;   
    
    public string[] Roles { get; init; } = Array.Empty<string>();
};

