using ECW.ApplicationCore.Entities.OrderAggregate;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECW.Infrastructure.Repositories;

public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
{
    public OrdersRepository(ProductContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetByBuyerIdAsync(string buyerId)
    {
        return await dbSet.Where(o => o.BuyerId == buyerId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ItemOrdered)
            .AsNoTracking()
            .ToListAsync();
    }
}