using ECW.ApplicationCore.DTOs.Basket;
using MediatR;

namespace ECW.ApplicationCore.Features.Baskets;

public class GetOrCreateBasketCommand : IRequest<BasketDto>
{
    public string BuyerId { get; set; }

    public GetOrCreateBasketCommand(string buyerId)
    {
        BuyerId = buyerId;
    }
}