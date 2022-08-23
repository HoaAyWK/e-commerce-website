using System.ComponentModel.DataAnnotations;

namespace ECW.ApplicationCore.DTOs.Product;

public class CreateProductRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Image { get; set; } = string.Empty;

    [Required]
    public int BrandId { get; set; }

    [Required]
    public int CategoryId { get; set; }
}