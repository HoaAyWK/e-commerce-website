using System.ComponentModel.DataAnnotations;

namespace ECW.ApplicationCore.DTOs.Product;

public class UpdateProductRequest
{
    [Required]
    [Range(1, 20000)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Image { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, 20000)]
    public int BrandId { get; set; }

    [Required]
    [Range(1, 20000)]
    public int CategoryId { get; set; }
}