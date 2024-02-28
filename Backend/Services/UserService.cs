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
using Shared.Enums;
using Shared.SettingsObjects;

namespace Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IOptionsMonitor<AdminLoginSettings> _adminLogin;
    private readonly ITokenProviderFactory _tokenProviderFactory;

    public UserService(IRepositoryManager repositoryManager,
                       IOptionsMonitor<AdminLoginSettings> adminLogin,
                       ITokenProviderFactory tokenProviderFactory)
    {
        _tokenProviderFactory = tokenProviderFactory;
        _adminLogin = adminLogin;
        _repositoryManager = repositoryManager;
    }

    public string Login(LoginDto login)
    {
        var user = _repositoryManager.UserRepository.GetUserByUsername(login.Username) ?? throw new Exception();

        bool correctPassword = BCrypt.Net.BCrypt.Verify(user.Password, login.Password);
        if (!correctPassword) throw new Exception();

        ITokenProviderService tokenProvider;
        if (user is Admin) tokenProvider = _tokenProviderFactory.GetTokenProviderService(Role.Admin);
        else tokenProvider = _tokenProviderFactory.GetTokenProviderService(Role.Barber);

        return tokenProvider.GenerateToken();
    }

    private bool IsAdmin(LoginDto login)
    {
        if (!login.Username.Equals(_adminLogin.CurrentValue.Username)) return false;
        if (!BCrypt.Net.BCrypt.Verify(login.Password, _adminLogin.CurrentValue.Password)) return false;

        return true;
    }
}
