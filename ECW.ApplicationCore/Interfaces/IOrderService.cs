using ECW.ApplicationCore.DTOs.Order;
using ECW.ApplicationCore.Entities.OrderAggregate;

namespace ECW.ApplicationCore.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
    
    Task<OrderDto> CreateOrderAsync(CreateOrderRequest request);

    Task<IEnumerable<OrderDto>> GetMyOrdersAsync(string buyerId);
}
