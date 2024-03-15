using Domain.Entities;
using Domain.Repository;
using Services.Abstractions;
using Shared.DataTransferObjects;
using Shared.Enums;

namespace Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ITokenProviderFactory _tokenProviderFactory;

    public UserService(IRepositoryManager repositoryManager,
                       ITokenProviderFactory tokenProviderFactory)
    {
        _tokenProviderFactory = tokenProviderFactory;
        _repositoryManager = repositoryManager;
    }

    public string Login(LoginDto login)
    {
        var user = _repositoryManager.UserRepository.GetUserByUsername(login.Username) ?? throw new Exception();

        // bool correctPassword = BCrypt.Net.BCrypt.Verify(user.Password, login.Password);
        bool correctPassword = user.Password.Equals(login.Password);
        if (!correctPassword) throw new Exception();

        ITokenProviderService tokenProvider;
        if (user is Admin) tokenProvider = _tokenProviderFactory.GetTokenProviderService(Role.Admin);
        else tokenProvider = _tokenProviderFactory.GetTokenProviderService(Role.Barber);

        return tokenProvider.GenerateToken();
    }
}
