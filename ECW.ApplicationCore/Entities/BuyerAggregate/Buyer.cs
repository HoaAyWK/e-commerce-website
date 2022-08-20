using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Entities.BuyerAggregate;

public class Buyer : BaseEntity, IAggregateRoot
{
    public string IdentityGuid { get; private set; } = string.Empty;

    private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();

    public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

    private Buyer()
    {
    }

    public Buyer(string identity) : this()
    {
        IdentityGuid = identity;
    }
}