using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Configurations;
using Shared.FilterObjects;

namespace Persistence.Repository;

public class BarberRepository : IBarberRepository
{
    private readonly RepositoryDbContext _dbContext;
    private readonly PageSettings _pageSettings;
    public BarberRepository(RepositoryDbContext dbContext, IOptionsMonitor<PageSettings> pageSettings)
    {
        _pageSettings = pageSettings.CurrentValue;
        _dbContext = dbContext;
    }

    public (int, List<Barber>) GetAll(BarberFilterObject? filterObject)
    {
        IQueryable<Barber> barbers = _dbContext.Barbers.Include(b => b.MyAppointments).AsNoTracking();

        if (filterObject is null)
            return (barbers.Count(), barbers.ToList());

        if (filterObject.Username is not null)
            barbers = barbers.Where(b => b.Username.ToLower().Contains(filterObject.Username.ToLower()));

        if (filterObject.Gender is not null)
            barbers = barbers.Where(b => b.Gender == filterObject.Gender);

        if (filterObject.SortByPopularity is not null)
        {
            barbers = filterObject.SortByPopularity.Value
                ? barbers.OrderByDescending(barber => barber.AppointmentsCount)
                : barbers.OrderBy(barber => barber.AppointmentsCount);
        }

        if (filterObject.SortByRating is not null)
        {
            barbers = filterObject.SortByRating.Value
                ? barbers.OrderByDescending(barber => barber.Rating)
                : barbers.OrderBy(barber => barber.Rating);
        }

        int barbersCount = barbers.Count();

        // Pagination
        if ((filterObject.PageNumber is not null) && (filterObject.PageSize is not null))
        {
            barbers = barbers.Skip(((short)filterObject.PageNumber - 1) * (short)filterObject.PageSize)
                             .Take((short)filterObject.PageSize);
        }
        else
        {
            barbers = barbers.Skip(((short)_pageSettings.DefaultPageNumber - 1) * (short)_pageSettings.DefaultPageSize)
                             .Take((short)_pageSettings.DefaultPageSize);
        }

        return (barbersCount, barbers.ToList());
    }

    public Barber GetById(Guid barberId)
    {
        return _dbContext.Barbers.AsNoTracking().FirstOrDefault(x => x.Id == barberId)!;
    }
}
