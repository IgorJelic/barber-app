using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Services.Abstractions;

namespace Services;

public class AdminTokenProviderService : ITokenProviderService
{
    public string GenerateToken(object? user = null)
    {
        List<Claim> claims = new()
        {
            new("id", string.Empty),
            new("username", "Administrator"),
            new("role", "admin")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("s3cret_k3y"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:7065",
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signingCredentials
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }
}
