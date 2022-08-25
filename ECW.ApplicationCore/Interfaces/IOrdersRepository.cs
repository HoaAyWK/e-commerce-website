using ECW.ApplicationCore.Entities.OrderAggregate;

namespace ECW.ApplicationCore.Interfaces;

public interface IOrdersRepository : IGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetByBuyerIdAsync(string buyerId);
}