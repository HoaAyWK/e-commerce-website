using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Entities.BasketAggregate;

public class Basket : BaseEntity, IAggregateRoot
{
    private readonly List<BasketItem> _items = new List<BasketItem>();
    public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

    public string BuyerId { get; private set; } = string.Empty;

    public int TotalItems => _items.Sum(i => i.Quantity);

    public Basket(string buyerId)
    {
        BuyerId = buyerId;
    }

    public void AddItem(int productId, decimal unitPrice, int quantity = 1)
    {
        var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
        if (existingItem == null)
        {
            _items.Add(new BasketItem(productId, quantity, unitPrice));

            return;
        }

        existingItem.AddQuantity(quantity);
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }

    public void SetNewBuyerId(string buyerId)
    {
        BuyerId = buyerId;
    }
}