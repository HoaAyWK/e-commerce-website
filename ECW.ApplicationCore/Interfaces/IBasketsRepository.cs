using ECW.ApplicationCore.Entities.BasketAggregate;

namespace ECW.ApplicationCore.Interfaces;

public interface IBasketsRepository : IGenericRepository<Basket>
{
    Task<Basket?> GetByBuyerIdAsync(string buyerId);
}