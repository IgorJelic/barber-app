
using Domain.Entities;

namespace Domain.Repository;

public interface IBarberRepository
{
    List<Barber> GetAll();
    Barber GetById(Guid barberId);
}
