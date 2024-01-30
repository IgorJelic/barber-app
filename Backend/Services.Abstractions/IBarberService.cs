using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Services.Abstractions;

public interface IBarberService
{
    List<BarberDto> GetAllBarbers(BarberFilterObject filterObject);
    BarberDto GetBarberById(Guid barberId);
}
