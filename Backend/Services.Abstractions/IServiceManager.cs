namespace Services.Abstractions;

public interface IServiceManager
{
    IBarberService BarberService { get; }
    IAppointmentService AppointmentService { get; }
    ICustomerService CustomerService { get; }
}
