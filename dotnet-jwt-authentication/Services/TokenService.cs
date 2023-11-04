using dotnet_jwt_authentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnet_jwt_authentication.Services;


public interface ITokenService
{
    string TokenGenerate(User user);
}


public class TokenService : ITokenService
{
    public string TokenGenerate(User user) 
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Configurations.TokenSecret.PrivateKey);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
            Subject = GenerateClaims(user),
        };

        var token = handler.CreateToken(tokenDescriptor);

        var strToken = handler.WriteToken(token);
        return strToken;
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Email));

        foreach (var role in user.Roles)
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));

        return claimsIdentity;
    }
}
