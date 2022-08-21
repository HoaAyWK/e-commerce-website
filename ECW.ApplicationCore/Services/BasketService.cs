using ECW.ApplicationCore.Entities.BasketAggregate;
using ECW.ApplicationCore.Exceptions;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class BasketService : IBasketService
{
    private readonly IUnitOfWork _unitOfWork;

    public BasketService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Basket> AddItemToBasket(string username, int productId, decimal price, int quantity = 1)
    {
        var basket = await _unitOfWork.Baskets.GetByBuyerIdAsync(username);

        if (basket == null)
        {
            basket = new Basket(username);
            await _unitOfWork.Baskets.AddAsync(basket);
        }

        basket.AddItem(productId, price, quantity);
        _unitOfWork.Baskets.Update(basket);
        await _unitOfWork.CompleteAsync();
        
        return basket;
    }

    public async Task DeleteBasketAsync(int basketId)
    {
        var existingBasket = await _unitOfWork.Baskets.GetByIdAsync(basketId);
        
        if (existingBasket is null)
            throw new BasketNotFoundException(basketId);

        _unitOfWork.Baskets.Delete(existingBasket);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<Basket> SetQuantities(int basketId, Dictionary<string, int> quantities)
    {
        var basket = await _unitOfWork.Baskets.GetByIdAsync(basketId);
        
        if (basket == null)
            throw new BasketNotFoundException(basketId);

        foreach (var item in basket.Items)
        {
            if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
            {
                item.SetQuantity(quantity);
            }
        }

        basket.RemoveEmptyItems();
        _unitOfWork.Baskets.Update(basket);

        return basket;
    }

    public async Task TransferBasketAsync(string anonymousId, string userName)
    {
        var anonymousBasket = await _unitOfWork.Baskets.GetByBuyerIdAsync(anonymousId);

        if (anonymousBasket == null)
            return;
        
        var userBasket = await _unitOfWork.Baskets.GetByBuyerIdAsync(userName);
        
        if (userBasket == null)
        {
            userBasket = new Basket(userName);
            await _unitOfWork.Baskets.AddAsync(userBasket);
        }

        foreach (var item in anonymousBasket.Items)
        {
            userBasket.AddItem(item.ProductId, item.UnitPrice, item.Quantity);
        }

        _unitOfWork.Baskets.Update(userBasket);
        _unitOfWork.Baskets.Delete(anonymousBasket);
        await _unitOfWork.CompleteAsync();
    }
}