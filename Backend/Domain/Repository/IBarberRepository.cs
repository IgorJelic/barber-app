
using Domain.Entities;

namespace Domain.Repository;

public interface IBarberRepository
{
    List<Barber> GetAll();
    List<Barber> GetById(Guid barberId);
}
