namespace ECW.ApplicationCore.DTOs.Order;

public class OrderItemDto
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int Units { get; set; }

    public decimal Discount => 0;
}