namespace Shared.FilterObjects;

public abstract class QueryStringParameters
{
    const int maxPageSize = 10;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 6;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}
