using Domain.Repository;
using Mapster;
using Services.Abstractions;
using Shared.DataTransferObjects;
using Shared.FilterObjects;

namespace Services;

public class BarberService : IBarberService
{
    private readonly IRepositoryManager _repositoryManager;
    public BarberService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public List<BarberDto> GetAllBarbers(BarberFilterObject filterObject)
    {
        var barbers = _repositoryManager.BarberRepository.GetAll(filterObject);

        return barbers.Adapt<List<BarberDto>>();
    }

    public BarberDto GetBarberById(Guid barberId)
    {
        var barber = _repositoryManager.BarberRepository.GetById(barberId);

        return barber.Adapt<BarberDto>();
    }

}
