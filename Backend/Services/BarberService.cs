using Domain.Entities;
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

    public (int barbersCount, List<BarberDto> barbers) GetAllBarbers(BarberFilterObject filterObject)
    {
        var (barbersCount, barbers) = _repositoryManager.BarberRepository.GetAll(filterObject);

        return (barbersCount, barbers.Adapt<List<BarberDto>>());
    }

    public SingleBarberDto GetBarberById(Guid barberId)
    {
        var barber = _repositoryManager.BarberRepository.GetById(barberId);

        return barber.Adapt<SingleBarberDto>();
    }

}
