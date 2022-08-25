namespace ECW.ApplicationCore.DTOs.Basket;

public class BasketDto
{
    public int Id { get; set; }

    public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();

    public string BuyerId { get; set; } = string.Empty;

    public decimal Total()
    {
        return Math.Round(Items.Sum(i => i.UnitPrice * i.Quantity), 2);
    }
}