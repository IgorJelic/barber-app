namespace Domain.Entities;

public class Appointment
{
    public Guid Id { get; set; }
    // public Guid BarberId { get; set; }
    public Barber Barber { get; set; }
    public Customer Customer { get; set; }
    public DateTime AppointmentTime { get; set; }
    public short? Rating { get; set; }
    public bool IsCanceled { get; set; }
}
