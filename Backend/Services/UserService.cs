using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Domain.Entities;
using Domain.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstractions;
using Shared.DataTransferObjects;
using Shared.SettingsObjects;

namespace Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IOptionsMonitor<AdminLoginSettings> _adminLogin;
    public UserService(IRepositoryManager repositoryManager, IOptionsMonitor<AdminLoginSettings> adminLogin)
    {
        _adminLogin = adminLogin;
        _repositoryManager = repositoryManager;
    }
    public string Login(LoginDto login)
    {
        if (IsAdmin(login)) return "Admin";

        var barber = _repositoryManager.BarberRepository.GetByUsername(login.Username)
                        ?? throw new Exception();

        bool correctPassword = BCrypt.Net.BCrypt.Verify(barber.Password, login.Password);
        if (!correctPassword) throw new Exception();

        throw new NotImplementedException();
    }

    private bool IsAdmin(LoginDto login)
    {
        if (!login.Username.Equals(_adminLogin.CurrentValue.Username)) return false;
        if (!BCrypt.Net.BCrypt.Verify(login.Password, _adminLogin.CurrentValue.Password)) return false;

        return true;
    }

    private static string CreateAdminToken()
    {
        List<Claim> claims = new()
        {
            new("id", String.Empty),
            new("username", "Administrator"),
            new("role", "admin")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("s3cret_k3y"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:5001",
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signingCredentials
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }

    private static string CreateToken(Barber barber)
    {
        List<Claim> claims = new()
        {
            new("id", barber.Id.ToString()),
            new("username", barber.Username.ToString()),
            new("role", "barber")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("s3cret_k3y"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:5001",
            claims: claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signingCredentials
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return tokenString;
    }

}
