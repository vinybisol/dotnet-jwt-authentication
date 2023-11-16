namespace dotnet_jwt_authentication.Models;

public class User()
{
    public Guid Id { get; init; } = Guid.Empty;
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public string[] Roles { get; init; } = ["Admin"];
}
