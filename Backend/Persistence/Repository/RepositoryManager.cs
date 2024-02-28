using Domain.Repository;
using Microsoft.Extensions.Options;
using Shared.SettingsObjects;

namespace Persistence.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly IBarberRepository _barberRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWorkRepository;

    public RepositoryManager(RepositoryDbContext dbContext, IOptionsMonitor<PageSettings> pageSettings)
    {
        _barberRepository = new BarberRepository(dbContext, pageSettings);
        _appointmentRepository = new AppointmentRepository(dbContext);
        _unitOfWorkRepository = new UnitOfWork(dbContext);
        _userRepository = new UserRepository(dbContext);
    }

    public IBarberRepository BarberRepository => _barberRepository;

    public IAppointmentRepository AppointmentRepository => _appointmentRepository;

    public IUnitOfWork UnitOfWork => _unitOfWorkRepository;

    public IUserRepository UserRepository => _userRepository;
}
