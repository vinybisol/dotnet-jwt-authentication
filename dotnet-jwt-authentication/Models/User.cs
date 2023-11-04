namespace dotnet_jwt_authentication.Models;

public record User(int Id, string Email, string Password, string[] Roles);

