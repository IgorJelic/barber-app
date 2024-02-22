namespace Shared.DataTransferObjects;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public Guid BarberId { get; set; }
    // public BarberDto Barber { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public DateTime AppointmentTime { get; set; }
    public short Rating { get; set; }
}
