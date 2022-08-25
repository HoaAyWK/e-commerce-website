using System.ComponentModel.DataAnnotations;
using ECW.ApplicationCore.Entities.OrderAggregate;

namespace ECW.ApplicationCore.DTOs.Order;

public class CreateOrderRequest
{
    [Required]
    public string BuyerId { get; set; } = default!;

    [Required]
    public Address ShippingAddress { get; set; } = default!;

    public List<OrderItemRequest> OrderItems { get; set; } = default!;
}