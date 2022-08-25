using System.ComponentModel.DataAnnotations;

namespace ECW.ApplicationCore.DTOs.Basket;

public class BasketItemDto
{
    public int Id { get; set; }

    public int ProdutId { get; set; }

    public string? ProductName { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal OldUnitPrice { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be bigger than 0")]
    public int Quantity { get; set; }

    public string? Image { get; set; }
}