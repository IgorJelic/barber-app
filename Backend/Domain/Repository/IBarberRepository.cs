
using Domain.Entities;
using Shared.FilterObjects;

namespace Domain.Repository;

public interface IBarberRepository
{
    List<Barber> GetAll(BarberFilterObject? filterObject);
    Barber GetById(Guid barberId);
}
