namespace Domain.Repository;

public interface IRepositoryManager
{
    IBarberRepository BarberRepository { get; }
    IAppointmentRepository AppointmentRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}
