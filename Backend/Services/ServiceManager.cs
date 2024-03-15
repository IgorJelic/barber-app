using Domain.Repository;
using Services.Abstractions;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ITokenProviderFactory _tokenProviderFactory;
    public ServiceManager(IRepositoryManager repositoryManager,
                          ITokenProviderFactory tokenProviderFactory)
    {
        _tokenProviderFactory = tokenProviderFactory;
        _repositoryManager = repositoryManager;
    }

    public IBarberService BarberService => new BarberService(_repositoryManager);
    public IAppointmentService AppointmentService => new AppointmentService(_repositoryManager);
    public IUserService UserService => new UserService(_repositoryManager, _tokenProviderFactory);

}
