using ECW.ApplicationCore.Entities.OrderAggregate;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Data;

namespace ECW.Infrastructure.Repositories;

public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
{
    public OrdersRepository(ProductContext context) : base(context)
    {
    }
}