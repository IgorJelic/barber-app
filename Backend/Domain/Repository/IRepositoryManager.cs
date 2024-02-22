namespace Domain.Repository;

public interface IRepositoryManager
{
    IBarberRepository BarberRepository { get; }
    IAppointmentRepository AppointmentRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}
