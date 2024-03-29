using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Enums;
using Shared.FilterObjects;
using Shared.Pagination;
using Shared.SettingsObjects;

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

    public (int, List<Barber>) GetAll(BarberFilterObject? filterObject = null)
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
            if (filterObject.SortByPopularity.Value != Sorting.None)
            {
                bool descending = filterObject.SortByPopularity.Value == Sorting.Descending;
                barbers = descending
                    ? barbers.OrderByDescending(barber => barber.MyAppointments.Count)
                    : barbers.OrderBy(barber => barber.MyAppointments.Count);
            }
        }

        if (filterObject.SortByRating is not null)
        {
            if (filterObject.SortByRating.Value != Sorting.None)
            {
                bool descending = filterObject.SortByRating.Value == Sorting.Descending;
                barbers = descending
                    ? barbers.OrderByDescending(barber => barber.Rating)
                    : barbers.OrderBy(barber => barber.Rating);
            }
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

    public PagedList<Barber> GetBarbers(BarberParameters parameters)
    {
        throw new NotImplementedException();
    }

    private void SearchByUsername(ref IQueryable<Barber> barbers, string barberUsername)
    {
        if (!barbers.Any() || string.IsNullOrWhiteSpace(barberUsername)) return;

        barbers = barbers.Where(b => b.Username.ToLower().Contains(barberUsername.Trim().ToLower()));
    }

    public Barber GetById(Guid barberId)
    {
        return _dbContext.Barbers.Include(b => b.MyAppointments).FirstOrDefault(x => x.Id == barberId)!;
    }

    public Barber GetByUsername(string username)
    {
        return _dbContext.Barbers.FirstOrDefault(b => b.Username.Equals(username));
    }


    public void Insert(Barber barber)
    {
        _dbContext.Barbers.Add(barber);
    }

}
