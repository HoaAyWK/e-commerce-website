using ECW.ApplicationCore.Entities.OrderAggregate;

namespace ECW.ApplicationCore.DTOs.Order;

public class OrderDto
{
    public int OrderNumber { get; set; }
    
    public DateTimeOffset OrderDate { get; set; }

    public decimal Total { get; set; }

    public Address ShippingAddress { get; set; } = null!;

    public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
}