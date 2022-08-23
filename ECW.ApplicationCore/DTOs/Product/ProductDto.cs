namespace ECW.ApplicationCore.DTOs.Product;

public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int BrandId { get; set; }

    public int CategoryId { get; set; }
}