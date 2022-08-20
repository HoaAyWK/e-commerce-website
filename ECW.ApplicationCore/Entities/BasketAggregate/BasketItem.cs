namespace ECW.ApplicationCore.Entities.BasketAggregate;

public class BasketItem : BaseEntity
{
    public decimal UnitPrice { get; private set; }

    public int Quantity { get; private set; }

    public int ProductId { get; private set; }

    public int BasketId { get; private set; }

    public BasketItem(int productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }

}