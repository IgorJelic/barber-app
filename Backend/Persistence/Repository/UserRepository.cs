using Domain.Entities;
using Domain.Repository;

namespace Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly RepositoryDbContext _dbContext;
    public UserRepository(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User GetUserByUsername(string username)
    {
        var admin = _dbContext.Admins.FirstOrDefault(a => a.Username.Equals(username));
        if (admin is not null) return admin;
        
        return _dbContext.Barbers.FirstOrDefault(b => b.Username.Equals(username))!;
    }

}
