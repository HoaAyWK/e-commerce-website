using ECW.ApplicationCore.Entities.BasketAggregate;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECW.Infrastructure.Repositories;

public class BasketsRepository : GenericRepository<Basket>, IBasketsRepository
{
    public BasketsRepository(ProductContext context) : base(context)
    {
    }

    public override async Task<Basket?> GetByIdAsync(int id)
    {
        return await dbSet.Where(b => b.Id == id)
            .Include(b => b.Items)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<Basket?> GetByBuyerIdAsync(string buyerId)
    {
        return await dbSet.Where(b => b.BuyerId == buyerId)
            .Include(b => b.Items)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
}