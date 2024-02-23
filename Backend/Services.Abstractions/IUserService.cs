using Shared.DataTransferObjects;

namespace Services.Abstractions;

public interface IUserService
{
    string Login(LoginDto login);
}
