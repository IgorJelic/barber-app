using Domain.Repository;
using Microsoft.Extensions.Options;
using Services.Abstractions;
using Shared.SettingsObjects;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IOptionsMonitor<AdminLoginSettings> _adminLogin;
    private readonly ITokenProviderFactory _tokenProviderFactory;
    public ServiceManager(IRepositoryManager repositoryManager,
                          IOptionsMonitor<AdminLoginSettings> adminLogin,
                          ITokenProviderFactory tokenProviderFactory)
    {
        _tokenProviderFactory = tokenProviderFactory;
        _adminLogin = adminLogin;
        _repositoryManager = repositoryManager;
    }

    public IBarberService BarberService => new BarberService(_repositoryManager);
    public IAppointmentService AppointmentService => new AppointmentService(_repositoryManager);
    public IUserService UserService => new UserService(_repositoryManager, _adminLogin, _tokenProviderFactory);

}
