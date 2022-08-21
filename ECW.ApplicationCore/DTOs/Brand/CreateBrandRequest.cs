using System.ComponentModel.DataAnnotations;

namespace ECW.ApplicationCore.DTOs.Brand;

public class CreateBrandRequest
{
    [Required]
    public string Name { get; set; } = null!;
}