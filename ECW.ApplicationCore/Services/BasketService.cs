using ECW.ApplicationCore.Entities.BasketAggregate;
using ECW.ApplicationCore.Exceptions;
using ECW.ApplicationCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace ECW.ApplicationCore.Services;

public class BasketService : IBasketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public BasketService(IUnitOfWork unitOfWork, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
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
        await _unitOfWork.Baskets.DeleteAsync(basketId);
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
                if (_logger != null) 
                    _logger.LogInformation($"Updating quantity of item Id: {item.Id}");

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