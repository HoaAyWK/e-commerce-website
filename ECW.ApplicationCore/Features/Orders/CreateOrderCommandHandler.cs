using ECW.ApplicationCore.DTOs.Order;
using ECW.ApplicationCore.Interfaces;
using MediatR;

namespace ECW.ApplicationCore.Features.Orders;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly IOrderService _orderService;

    public CreateOrderCommandHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<OrderDto> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var orderDto = await _orderService.CreateOrderAsync(request.Order);

        return orderDto;
    }
}