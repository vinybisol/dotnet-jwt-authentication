using dotnet_jwt_authentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace dotnet_jwt_authentication.Services;

public class TokenService
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
        };

        var token = handler.CreateToken(tokenDescriptor);

        var strToken = handler.WriteToken(token);
        return strToken;
    }
}
