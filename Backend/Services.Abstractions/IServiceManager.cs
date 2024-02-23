namespace Services.Abstractions;

public interface IServiceManager
{
    IBarberService BarberService { get; }
    IAppointmentService AppointmentService { get; }
    IUserService UserService { get; }
}
