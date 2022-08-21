using System.ComponentModel.DataAnnotations;

namespace ECW.ApplicationCore.DTOs.Brand;

public class UpdateBrandRequest
{
    [Range(1, 20000)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}