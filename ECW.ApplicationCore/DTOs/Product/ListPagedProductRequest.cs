namespace ECW.ApplicationCore.DTOs.Product;

public class ListPagedProductRequest
{
    public int PageSize { get; set; } = 6;

    public int PageIndex { get; set; } = 1;

    public int? BrandId { get; set; }

    public int? CategoryId { get; set; }
}