namespace Shared.FilterObjects;

public class AppointmentFilterObject
{
    public DateTime Day { get; set; } = DateTime.Today;
    public short PageNumber { get; set; } = 1;
    public short PageSize { get; set; } = 8;
}
