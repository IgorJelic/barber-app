using Domain.Entities;

namespace Domain.Repository;

public interface IUserRepository
{
    User GetUserByUsername(string username);
}
