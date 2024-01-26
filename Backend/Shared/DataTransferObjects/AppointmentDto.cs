namespace Shared.DataTransferObjects;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public Guid BarberId { get; set; }
    public CustomerDto Customer { get; set; }
    public DateTime AppointmentTime { get; set; }
    public short Rating { get; set; }
}
