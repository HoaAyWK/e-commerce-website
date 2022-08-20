namespace ECW.ApplicationCore.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public ItemOrdered? ItemOrdered { get; private set; }

    public decimal UnitPrice { get; private set; }
    
    public int Units { get; private set; }

    private OrderItem()
    {
    }

    public OrderItem(ItemOrdered itemOrdered, decimal unitPrice, int units)
    {
        ItemOrdered = itemOrdered;
        UnitPrice = unitPrice;
        Units = units;
    }
}