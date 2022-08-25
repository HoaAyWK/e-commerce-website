using ECW.ApplicationCore.DTOs.Order;
using ECW.ApplicationCore.Interfaces;
using MediatR;

namespace ECW.ApplicationCore.Features.Orders;

public class GetOrdersCommandHandler : IRequestHandler<GetOrdersCommand, IEnumerable<OrderDto>>
{
    public IOrderService _orderSerive;

    public GetOrdersCommandHandler(IOrderService orderService)
    {
        _orderSerive = orderService;
    }

    public async Task<IEnumerable<OrderDto>> Handle(
        GetOrdersCommand request, CancellationToken cancellationToken)
    {
        var orders = await _orderSerive.GetMyOrdersAsync(request.BuyerId);

        return orders;
    }
}