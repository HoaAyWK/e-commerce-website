using ECW.ApplicationCore.DTOs.Order;
using MediatR;

namespace ECW.ApplicationCore.Features.Orders;

public class GetOrdersCommand : IRequest<IEnumerable<OrderDto>>
{
    public string BuyerId { get; set; }

    public GetOrdersCommand(string buyerId)
    {
        BuyerId = buyerId;
    }
}