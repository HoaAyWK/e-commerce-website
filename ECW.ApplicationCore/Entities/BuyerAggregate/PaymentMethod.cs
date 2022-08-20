namespace ECW.ApplicationCore.Entities.BuyerAggregate;

public class PaymentMethod : BaseEntity
{
    public string Alias { get; private set; } = string.Empty;

    public string CardId { get; private set; } = string.Empty;

    public string Last4 { get; private set; } = string.Empty;
}