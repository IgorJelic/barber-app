namespace Domain.Repository;

public interface IRepositoryManager
{
    IBarberRepository BarberRepository { get; }
    IAppointmentRepository AppointmentRepository { get; }
    IUserRepository UserRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}
