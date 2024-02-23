using BCrypt.Net;
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

    public BarberDto GetBarberById(Guid barberId)
    {
        var barber = _repositoryManager.BarberRepository.GetById(barberId);

        return barber.Adapt<BarberDto>();
    }

    public BarberDto RegisterNewBarber(BarberRegisterDto barber)
    {
        var newBarber = barber.Adapt<Barber>();
        var allBarbers = _repositoryManager.BarberRepository.GetAll().barbers;

        bool exists = allBarbers.Any(b => b.Username == barber.Username);
        if (exists) throw new Exception();

        newBarber.Password = BCrypt.Net.BCrypt.HashPassword(barber.Password);

        _repositoryManager.BarberRepository.Insert(newBarber);

        return newBarber.Adapt<BarberDto>();
    }
}
