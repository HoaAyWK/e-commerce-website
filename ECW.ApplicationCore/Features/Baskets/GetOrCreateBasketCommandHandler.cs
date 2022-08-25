using ECW.ApplicationCore.DTOs.Basket;
using ECW.ApplicationCore.Interfaces;
using MediatR;

namespace ECW.ApplicationCore.Features.Baskets;

public class GetOrCreateBasketCommandHandler : IRequestHandler<GetOrCreateBasketCommand, BasketDto>
{
    private readonly IBasketService _basketService;

    public GetOrCreateBasketCommandHandler(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<BasketDto> Handle(
        GetOrCreateBasketCommand request,
        CancellationToken cancellationToken)
    {
       return await _basketService.GetOrCreateBasketForUser(request.BuyerId);
    }
}