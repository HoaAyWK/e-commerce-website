using ECW.ApplicationCore.Entities.OrderAggregate;

namespace ECW.ApplicationCore.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
}
