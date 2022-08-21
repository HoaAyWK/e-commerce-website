using ECW.ApplicationCore.Entities.OrderAggregate;
using ECW.ApplicationCore.Exceptions;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateOrderAsync(int basketId, Address shippingAddress)
    {
        var basket = await _unitOfWork.Baskets.GetByIdAsync(basketId);

        if (basket == null)
            throw new BasketNotFoundException(basketId);
        
        if (!basket.Items.Any())
            throw new EmptyBasketOnCheckoutException();

        var products = await _unitOfWork.Products.GetByIdsAsync(basket.Items.Select(b => b.ProductId).ToArray());
        var basketItems = basket.Items.Select(item =>
        {
            var product = products.First(p => p.Id == item.ProductId);
            var productOrdered = new ItemOrdered(product.Id, product.Name, product.Image);
            var orderProduct = new OrderItem(productOrdered, item.UnitPrice, item.Quantity);

            return orderProduct;
        }).ToList();

        var order = new Order(basket.BuyerId, shippingAddress, basketItems);
        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.CompleteAsync();
    }
}