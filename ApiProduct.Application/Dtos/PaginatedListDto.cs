namespace ApiProduct.Application.Dtos;
public class PaginatedListDto<T>
{
    public List<T> Items { get; }
    public int TotalCount { get; }
    public int PageIndex { get; }
    public int PageSize { get; }

    public PaginatedListDto(List<T> items, int count, int pageIndex, int pageSize)
    {
        Items = items;
        TotalCount = count;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}
