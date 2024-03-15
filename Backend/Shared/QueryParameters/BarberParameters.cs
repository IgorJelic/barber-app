using Shared.Enums;

namespace Shared.FilterObjects;

public class BarberParameters : QueryStringParameters
{
    public string? Username { get; set; }
    public Sorting? SortByPopularity { get; set; } = Sorting.None;
    public Sorting? SortByRating { get; set; } = Sorting.None;
    public Gender? Gender { get; set; }
}
