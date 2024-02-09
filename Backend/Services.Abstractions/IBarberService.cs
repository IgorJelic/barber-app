using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Services.Abstractions;

public interface IBarberService
{
    (int barbersCount, List<BarberDto> barbers) GetAllBarbers(BarberFilterObject filterObject);
    SingleBarberDto GetBarberById(Guid barberId);
}
