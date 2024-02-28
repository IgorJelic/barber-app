using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Services.Abstractions;

namespace Services;

public class BarberTokenProviderService : ITokenProviderService
{
    public string GenerateToken(object? user = null)
    {
        var barber = user as Barber;

        List<Claim> claims = new()
        {
            new("id", barber!.Id.ToString()),
            new("username", barber.Username.ToString()),
            new("role", "barber")
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
