using Domain.Entities;

namespace Services.Abstractions;

public interface ITokenProviderService
{
    string GenerateToken(object? user = null);
}
