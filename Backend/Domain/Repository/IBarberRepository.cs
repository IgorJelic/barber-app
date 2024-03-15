using Domain.Entities;
using Shared.FilterObjects;
using Shared.Pagination;

namespace Domain.Repository;

public interface IBarberRepository
{
    (int barbersCount, List<Barber> barbers) GetAll(BarberFilterObject? filterObject = null);
    PagedList<Barber> GetBarbers(BarberParameters? parameters = null);
    Barber GetById(Guid barberId);
    Barber GetByUsername(string username);
    void Insert(Barber barber);
}
