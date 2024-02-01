using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shared.FilterObjects;

namespace Persistence.Repository;

public class BarberRepository : IBarberRepository
{
    private readonly RepositoryDbContext _dbContext;
    public BarberRepository(RepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public (int, List<Barber>) GetAll(BarberFilterObject? filterObject)
    {
        IQueryable<Barber> barbers = _dbContext.Barbers.Include(b => b.MyAppointments);

        if (filterObject is null)
            return (barbers.Count(), barbers.ToList());

        if (filterObject.Gender is not null)
            barbers = barbers.Where(b => b.Gender == filterObject.Gender);

        if (filterObject.SortByPopularity is not null)
        {
            barbers = filterObject.SortByPopularity.Value
                ? barbers.OrderByDescending(barber => barber.MyAppointments.Count)
                : barbers.OrderBy(barber => barber.MyAppointments.Count);
        }

        if (filterObject.SortByRating is not null)
        {
            barbers = filterObject.SortByRating.Value
                ? barbers.OrderByDescending(barber => barber.CalculateRating())
                : barbers.OrderBy(barber => barber.CalculateRating());
        }

        int barbersCount = barbers.Count();

        // Pagination
        if ((filterObject.PageNumber is not null) && (filterObject.PageSize is not null))
        {
            barbers = barbers.Skip(((short)filterObject.PageNumber - 1) * (short)filterObject.PageSize)
                             .Take((short)filterObject.PageSize);
        }

        return (barbersCount, barbers.ToList());
    }

    public Barber GetById(Guid barberId)
    {
        return _dbContext.Barbers.FirstOrDefault(x => x.Id == barberId)!;
    }
}
