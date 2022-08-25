using ECW.ApplicationCore.DTOs.Basket;
using ECW.ApplicationCore.Entities.BasketAggregate;
using ECW.ApplicationCore.Exceptions;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class BasketService : IBasketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBasketQueryService _basketQueryService;

    public BasketService(IUnitOfWork unitOfWork, IBasketQueryService basketQueryService)
    {
        _unitOfWork = unitOfWork;
        _basketQueryService = basketQueryService;
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

    public async Task<BasketDto> GetOrCreateBasketForUser(string username)
    {
        var basket = await _unitOfWork.Baskets.GetByBuyerIdAsync(username);

        if (basket == null)
        {
            return await CreateBasketForUser(username);
        }

        var basketDto = await Map(basket);

        return basketDto;
    }

    private async Task<BasketDto> CreateBasketForUser(string username)
    {
        var basket = new Basket(username);
        var result = await _unitOfWork.Baskets.AddAsync(basket);
        await _unitOfWork.CompleteAsync();

        return new BasketDto
        {
            BuyerId = username,
            Id = result.Id
        };
    }

    private async Task<List<BasketItemDto>> GetBasketItems(IReadOnlyCollection<BasketItem> basketItems)
    {
        var products = await _unitOfWork.Products.GetByIdsAsync(basketItems.Select(b => b.Id).ToArray());
        var items = basketItems.Select(basketItem =>
        {
            var product = products.First(p => p.Id == basketItem.ProductId);
            var basketItemDto = new BasketItemDto
            {
                Id = basketItem.Id,
                UnitPrice = basketItem.UnitPrice,
                Quantity = basketItem.Quantity,
                ProductName = product.Name,
                ProdutId = basketItem.ProductId,
                Image = product.Image
            };

            return basketItemDto;
        })
        .ToList();

        return items;
    }

    public async Task<BasketDto> Map(Basket basket)
    {
        return new BasketDto
        {
            BuyerId = basket.BuyerId,
            Id = basket.Id,
            Items = await GetBasketItems(basket.Items)
        };
    }

    public async Task<int> CountTotalBasketItems(string username)
    {
        var counter = await _basketQueryService.CountTotalBasketItems(username);

        return counter;
    }
}