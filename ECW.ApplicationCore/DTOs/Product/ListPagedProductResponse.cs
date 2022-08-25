namespace ECW.ApplicationCore.DTOs.Product;

public class ListPagedProductResponse
{
    public int Page { get; set; }

    public int PerPage { get; set; }

    public int Total { get; set; }

    public int PageCount { get; set; }
    
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
}