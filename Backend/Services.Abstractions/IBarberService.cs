using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Services.Abstractions;

public interface IBarberService
{
    (int barbersCount, List<BarberDto> barbers) GetAllBarbers(BarberFilterObject filterObject);
    BarberDto GetBarberById(Guid barberId);
    BarberDto RegisterNewBarber(BarberRegisterDto barber);
}
