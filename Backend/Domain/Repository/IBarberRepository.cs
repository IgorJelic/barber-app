
using Domain.Entities;
using Shared.FilterObjects;

namespace Domain.Repository;

public interface IBarberRepository
{
    (int barbersCount, List<Barber> barbers) GetAll(BarberFilterObject? filterObject = null);
    Barber GetById(Guid barberId);
    Barber GetByUsername(string username);
    void Insert(Barber barber);
}
