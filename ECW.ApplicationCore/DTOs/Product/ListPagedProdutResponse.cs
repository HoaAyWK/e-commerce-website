namespace ECW.ApplicationCore.DTOs.Product;

public class ListPagedProductResponse
{
    public int PageCount { get; set; }
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
}