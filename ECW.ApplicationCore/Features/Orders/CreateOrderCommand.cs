using ECW.ApplicationCore.DTOs.Order;
using ECW.ApplicationCore.Entities.OrderAggregate;
using MediatR;

namespace ECW.ApplicationCore.Features.Orders;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public CreateOrderRequest Order;

    public CreateOrderCommand(CreateOrderRequest order)
    {
        Order = order;
    }
}