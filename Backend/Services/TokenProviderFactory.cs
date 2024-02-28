using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using Shared.Enums;

namespace Services;

public class TokenProviderFactory : ITokenProviderFactory
{
    private readonly IServiceProvider _serviceProvider;
    public TokenProviderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITokenProviderService GetTokenProviderService(Role role)
    {
        return role switch
        {
            Role.Admin => _serviceProvider.GetService<AdminTokenProviderService>()!,
            Role.Barber => _serviceProvider.GetService<BarberTokenProviderService>()!,
            Role.Customer => throw new ArgumentException("Still unsupported role"),
            _ => throw new ArgumentException("Unsupported role"),
        };
    }

}
