
using Domain.Entities;
using Shared.FilterObjects;

namespace Domain.Repository;

public interface IBarberRepository
{
    (int barbersCount, List<Barber> barbers) GetAll(BarberFilterObject? filterObject);
    Barber GetById(Guid barberId);
}
