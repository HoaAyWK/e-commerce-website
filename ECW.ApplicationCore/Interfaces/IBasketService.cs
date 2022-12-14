using ECW.ApplicationCore.DTOs.Basket;
using ECW.ApplicationCore.Entities.BasketAggregate;

namespace ECW.ApplicationCore.Interfaces;

public interface IBasketService
{
    Task TransferBasketAsync(string anonymousId, string userName);

    Task<Basket> AddItemToBasket(string username, int productId, decimal price, int quantity = 1);

    Task<Basket> SetQuantities(int basketId, Dictionary<string, int> quantities);

    Task DeleteBasketAsync(int basketId);

    Task <BasketDto> GetOrCreateBasketForUser(string username);

    Task<int> CountTotalBasketItems(string username);

    Task<BasketDto> Map(Basket basket);
}