namespace Shared.DataTransferObjects;

public class AppointmentCreateDto
{
    public Guid BarberId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime AppointmentTime { get; set; }
}
