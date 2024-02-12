using Shared.Enums;

namespace Shared.FilterObjects;

public class BarberFilterObject
{
    public string? Username { get; set; }
    // Count of total appointments by this barber
    public bool? SortByPopularity { get; set; }
    // Avg of barbers appointments ratings
    public bool? SortByRating { get; set; }
    public short? PageSize { get; set; }
    public short? PageNumber { get; set; }
    public Gender? Gender { get; set; }
}
