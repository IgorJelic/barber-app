using Domain.Repository;
using Services.Abstractions;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly IRepositoryManager _repositoryManager;
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public IBarberService BarberService => new BarberService(_repositoryManager);
    public IAppointmentService AppointmentService => new AppointmentService(_repositoryManager);
    public ICustomerService CustomerService => new CustomerService(_repositoryManager);
}
