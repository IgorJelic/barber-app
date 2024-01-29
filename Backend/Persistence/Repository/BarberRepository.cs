using Domain.Entities;
using Domain.Repository;

namespace Persistence.Repository;

public class BarberRepository : IBarberRepository
{
    private readonly RepositoryDbContext _dbContext;
    public BarberRepository(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Barber> GetAll()
    {
        throw new NotImplementedException();
    }

    public Barber GetById(Guid barberId)
    {
        return _dbContext.Barbers.FirstOrDefault(x => x.Id == barberId);
    }
}
