using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Entities.OrderAggregate;

public class Order : BaseEntity, IAggregateRoot
{
    public string BuyerId { get; private set; } = string.Empty;

    public DateTimeOffset OrderDate { get; private set; }

    public Address ShipToAddress { get; private set; } = null!;

    private readonly List<OrderItem> _orderItems = new List<OrderItem>();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    private Order()
    {
    }

    public Order(string buyerId, Address shipToAddress, List<OrderItem> items)
    {
        BuyerId = buyerId;
        ShipToAddress = shipToAddress;
        _orderItems = items;
    }

    public decimal Total()
    {
        var total = 0m;

        foreach (var item in _orderItems)
        {
            total += item.UnitPrice * item.Units;
        }

        return total;
    }
}