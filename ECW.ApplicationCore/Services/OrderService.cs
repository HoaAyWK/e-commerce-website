using AutoMapper;
using ECW.ApplicationCore.DTOs.Order;
using ECW.ApplicationCore.Entities.OrderAggregate;
using ECW.ApplicationCore.Exceptions;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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

    public async Task<OrderDto> CreateOrderAsync(CreateOrderRequest request)
    {   
        var orderItems = new List<OrderItem>();

        foreach (var item in request.OrderItems)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
            var itemOrdered = new ItemOrdered(product!.Id, product!.Name, product!.Image);
            var orderItem = new OrderItem(itemOrdered, product!.Price, item.Units);

            orderItems.Add(orderItem);
        }

        var order = new Order(request.BuyerId, request.ShippingAddress, orderItems);
        var result = await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.CompleteAsync();

        var orderDto = _mapper.Map<OrderDto>(result);

        return orderDto;
    }

    public async Task<IEnumerable<OrderDto>> GetMyOrdersAsync(string buyerId)
    {
        var orders = await _unitOfWork.Orders.GetByBuyerIdAsync(buyerId);
        var orderDtos = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);

        return orderDtos;
    }
}