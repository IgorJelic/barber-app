using Shared.Enums;

namespace Services.Abstractions;

public interface ITokenProviderFactory
{
    ITokenProviderService GetTokenProviderService(Role role);
}
