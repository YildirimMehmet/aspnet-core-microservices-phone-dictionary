namespace PhoneDirectory.Shared.Models;

public class PagedResponseDto<T>
{
    public IEnumerable<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }

    public PagedResponseDto(IEnumerable<T> items, int pageNumber, int pageSize, int totalRecords)
    {
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.Items = items;
        this.TotalRecords = totalRecords;
    }
}