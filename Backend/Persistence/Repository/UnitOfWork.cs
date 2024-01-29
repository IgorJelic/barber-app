using Domain.Repository;

namespace Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryDbContext _dbContext;
    public UnitOfWork(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

}
