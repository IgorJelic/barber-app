using Domain.Repository;
using Microsoft.Extensions.Options;
using Persistence.Configurations;

namespace Persistence.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly IBarberRepository _barberRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWorkRepository;

    public RepositoryManager(RepositoryDbContext dbContext, IOptionsMonitor<PageSettings> pageSettings)
    {
        _barberRepository = new BarberRepository(dbContext, pageSettings);
        _customerRepository = new CustomerRepository(dbContext);
        _appointmentRepository = new AppointmentRepository(dbContext);
        _unitOfWorkRepository = new UnitOfWork(dbContext);
    }

    public IBarberRepository BarberRepository => _barberRepository;

    public IAppointmentRepository AppointmentRepository => _appointmentRepository;

    public ICustomerRepository CustomerRepository => _customerRepository;

    public IUnitOfWork UnitOfWork => _unitOfWorkRepository;

}
