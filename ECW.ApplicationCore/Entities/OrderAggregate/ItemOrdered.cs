namespace ECW.ApplicationCore.Entities.OrderAggregate;

// ValueObject
public class ItemOrdered
{
    public string ProductName { get; private set; } = string.Empty;

    public string ProductImage { get; private set; } = string.Empty;

    public int ProductId { get; private set; }

    private ItemOrdered()
    {
    }

    public ItemOrdered(int productId, string productName, string productImage)
    {
        ProductId = productId;
        ProductName = productName;
        ProductImage = productImage;
    }
}